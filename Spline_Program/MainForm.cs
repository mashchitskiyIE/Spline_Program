using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Spline_Program
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            ZGC.GraphPane.IsFontsScaled = false;
            ZGC.GraphPane.YAxis.MajorGrid.IsVisible = ZGC.GraphPane.XAxis.MajorGrid.IsVisible = ZGC.GraphPane.YAxis.MinorGrid.IsVisible = ZGC.GraphPane.XAxis.MinorGrid.IsVisible = true;
            ZGC.GraphPane.YAxis.MajorGrid.DashOn = ZGC.GraphPane.XAxis.MajorGrid.DashOn = 10;
            ZGC.GraphPane.YAxis.MajorGrid.DashOff = ZGC.GraphPane.XAxis.MajorGrid.DashOff = 5;
            ZGC.GraphPane.YAxis.MinorGrid.DashOn = ZGC.GraphPane.XAxis.MinorGrid.DashOn = 1;
            ZGC.GraphPane.YAxis.MinorGrid.DashOff = ZGC.GraphPane.XAxis.MinorGrid.DashOff = 2;
            ZGC.MouseMove += new MouseEventHandler((object s, MouseEventArgs e) => ShowCurrentCursorPositionOnGraph());
            ZGC.Paint += new PaintEventHandler((object s, PaintEventArgs e) => ShowCurrentCursorPositionOnGraph());
            ZGC.GraphPane.Title.Text = "";
            ZGC.GraphPane.XAxis.Title.Text = "X";
            ZGC.GraphPane.YAxis.Title.Text = "Y";
            leftCondNUD.ValueChanged += new EventHandler((object s, EventArgs ea) => { if (ZGC.GraphPane.CurveList.Count != 0) { ReCalc(); ZGC.Invalidate(); } });
            rightCondNUD.ValueChanged += new EventHandler((object s, EventArgs ea) => { if (ZGC.GraphPane.CurveList.Count != 0) { ReCalc(); ZGC.Invalidate(); } });
            SplineComboBox.SelectedIndex = 0;
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView DGV = this.ActiveControl as DataGridView;
            if (DGV != null)
            {
                if (DGV.SelectedCells.Count > 1 || DGV.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Неподдерживаемая вставка: выберите одну ячейку.", "Программное сообщение");
                    DGV.ClearSelection();
                }
                else
                {
                    IDataObject data = Clipboard.GetDataObject();
                    string text = (string)data.GetData(DataFormats.Text);
                    if (text != null)
                    {
                        string[] lines = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        int r = DGV.SelectedCells[0].RowIndex, c = DGV.SelectedCells[0].ColumnIndex;
                        DGV.RowCount = r + lines.Length + 1;
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] line = lines[i].Split('\t');
                            for (int j = 0; j < line.Length && j + c < DGV.ColumnCount; j++) if (!DGV.Rows[r + i].Cells[j].ReadOnly) DGV.Rows[i + r].Cells[j + c].Value = line[j];
                        }
                    }
                    DGV.RefreshEdit();
                }
            }
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView DGV = this.ActiveControl as DataGridView;
            if (DGV != null)
            {
                DataObject d = DGV.GetClipboardContent();
                if (d != null) Clipboard.SetDataObject(d);
            }
        }

        private static void ChangeRows(double[,] m, double[] fv, int i1, int i2)
        {
            double rv;
            for (int j = 0; j < m.GetLength(1); j++) { rv = m[i1, j]; m[i1, j] = m[i2, j]; m[i2, j] = rv; }
            if (fv != null) { rv = fv[i1]; fv[i1] = fv[i2]; fv[i2] = rv; }
        }

        private static void SubtractionMtpRow(double[,] m, double[] fv, int i1, int i2, double mtp)
        {
            for (int j = 0; j < m.GetLength(1); j++) m[i1, j] -= m[i2, j] * mtp;
            if (fv != null) fv[i1] -= fv[i2] * mtp;
        }

        private static double MatrixToRightUpperTriangularMatrix(double[,] m, double[] fv)
        {
            double dtrmmtp = 1;
            int d = m.GetLength(0);
            for (int j = 0; j < d - 1; j++)
            {
                int ir = j;
                for (int i = j; i < d; i++) if (Math.Abs(m[i, j]) > Math.Abs(m[ir, j])) ir = i;
                if (ir != j) { ChangeRows(m, fv, ir, j); dtrmmtp *= -1; }
                for (int i = d - 1; i > j; i--) SubtractionMtpRow(m, fv, i, j, m[i, j] / m[j, j]);
            }
            return dtrmmtp;
        }

        private double[] GaussMethod(double[,] em, double[] fv)
        {
            int d = em.GetLength(0);
            double[] res = new double[d];
            MatrixToRightUpperTriangularMatrix(em, fv);
            for (int i = d - 1; i >= 0; i--)
            {
                for (int j = d - 1; j > i; j--)
                {
                    fv[i] -= em[i, j] * fv[j];
                }
                fv[i] = fv[i] / em[i, i];
            }
            return fv;
        }

        private double[,] CubicSplineInterpolation_Straight(PointPairList DF, double lC, double rC)
        {
            int n = (DF.Count - 1) * 4;
            double[,] em = new double[n, n];
            for (int i = 0; i < n; i++) for (int m = 0; m < n; m++) em[i, m] = 0;
            double[] ev = new double[n];
            for (int i = 0; i < n; i++) ev[i] = 0;
            int j = 0, k = 0;
            for (int i = 0; i < DF.Count - 1; i++)
            {
                em[j, k * 4] = 1;
                em[j, k * 4 + 1] = DF[i].X;
                em[j, k * 4 + 2] = Math.Pow(DF[i].X, 2);
                em[j, k * 4 + 3] = Math.Pow(DF[i].X, 3);
                ev[j] = DF[i].Y;
                j++;
                em[j, k * 4] = 1;
                em[j, k * 4 + 1] = DF[i + 1].X;
                em[j, k * 4 + 2] = Math.Pow(DF[i + 1].X, 2);
                em[j, k * 4 + 3] = Math.Pow(DF[i + 1].X, 3);
                ev[j] = DF[i + 1].Y;
                j++;
                k++;
            }
            k = 0;
            for (int i = 1; i < DF.Count - 1; i++)
            {
                em[j, k * 4 + 1] = 1;
                em[j, k * 4 + 2] = 2 * DF[i].X;
                em[j, k * 4 + 3] = 3 * Math.Pow(DF[i].X, 2);
                em[j, (k + 1) * 4 + 1] = -1;
                em[j, (k + 1) * 4 + 2] = -2 * DF[i].X;
                em[j, (k + 1) * 4 + 3] = -3 * Math.Pow(DF[i].X, 2);
                ev[j] = 0;
                j++;
                em[j, k * 4 + 2] = 2;
                em[j, k * 4 + 3] = 6 * DF[i].X;
                em[j, (k + 1) * 4 + 2] = -2;
                em[j, (k + 1) * 4 + 3] = -6 * DF[i].X;
                ev[j] = 0;
                j++;
                k++;
            }
            em[j, 2] = 2;
            em[j, 3] = 6 * DF[0].X;
            ev[j] = lC;
            j++;
            em[j, n - 2] = 2;
            em[j, n - 1] = 6 * DF.Last().X;
            ev[j] = rC;
            ev = GaussMethod(em, ev);
            double[,] ans = new double[DF.Count - 1, 4];
            for (int i = 0; i < ev.Length; i += 4)
            {
                j = i / 4;
                ans[j, 0] = ev[i];
                ans[j, 1] = ev[i + 1];
                ans[j, 2] = ev[i + 2];
                ans[j, 3] = ev[i + 3];
            }
            return ans;
        }

        private void ReCalc()
        {
            ZGC.GraphPane.CurveList.Clear();
            PointPairList SF = new PointPairList();
            int rn = 0;
            double xin, yin;
            while (SDGV.Rows[rn].Cells[0].Value != null && double.TryParse(SDGV.Rows[rn].Cells[0].Value.ToString(), out xin) && SDGV.Rows[rn].Cells[1].Value != null && double.TryParse(SDGV.Rows[rn].Cells[1].Value.ToString(), out yin)) { SF.Add(xin, yin); rn++; }
            if (SF.Count < 2) return;
            SF.Sort(SortType.XValues);
            PointPairList RF = new PointPairList(), SFX = new PointPairList();
            rn = 0;
            while (RFDGV.Rows[rn].Cells[0].Value != null && double.TryParse(RFDGV.Rows[rn].Cells[0].Value.ToString(), out xin)) { RF.Add(xin, double.NaN); rn++; }
            if (SF.Count == 2)
            {
                double k = (SF[1].Y - SF[0].Y) / (SF[1].X - SF[0].X), b = SF[1].Y - k * SF[1].X;
                for (int i = 0; i < RF.Count; i++) if (RF[i].X >= SF[0].X && RF[i].X < SF[1].X) RF[i].Y = k * RF[i].X + b;
            }
            else
            {
                double[,] spln;
                double dx = (SF.Last().X - SF.First().X) / 1000, x = SF.First().X + dx;
                int sn = 0;
                switch (SplineComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            spln = CubicSplineInterpolation_Straight(SF, Convert.ToDouble(leftCondNUD.Value), Convert.ToDouble(rightCondNUD.Value));
                            SFX.Add(SF.First());
                            while (x < SF.Last().X)
                            {
                                while (x > SF[sn + 1].X) { SFX.Add(SF[sn + 1]); sn++; }
                                SFX.Add(x, spln[sn, 0] + spln[sn, 1] * x + spln[sn, 2] * Math.Pow(x, 2) + spln[sn, 3] * Math.Pow(x, 3));
                                x += dx;
                            }
                            SFX.Add(SF.Last());
                            sn = 0;
                            for (int i = 0; i < RF.Count; i++)
                            {
                                while (RF[i].X > SF[sn + 1].X) sn++;
                                RF[i].Y = spln[sn, 0] + spln[sn, 1] * RF[i].X + spln[sn, 2] * Math.Pow(RF[i].X, 2) + spln[sn, 3] * Math.Pow(RF[i].X, 3);
                            }
                            break;
                        }
                    case 1:
                        {
                            spln = AkimaSpline(SF);
                            SFX.Add(SF.First());
                            while (x < SF.Last().X)
                            {
                                while (x > SF[sn + 1].X) { SFX.Add(SF[sn + 1]); sn++; }
                                double xd = (x - SF[sn].X);
                                //double xy = y[p - 1] + (t[p - 1] + (C[p - 1] + D[p - 1] * xd) * xd) * xd;
                                SFX.Add(x, spln[sn, 0] + (spln[sn, 1] + (spln[sn, 2] + spln[sn, 3] * (x - SF[sn].X)) * (x - SF[sn].X)) * (x - SF[sn].X));
                                x += dx;
                            }
                            SFX.Add(SF.Last());
                            sn = 0;
                            for (int i = 0; i < RF.Count; i++)
                            {
                                while (RF[i].X > SF[sn + 1].X) sn++;
                                RF[i].Y = spln[sn, 0] + (spln[sn, 1] + (spln[sn, 2] + spln[sn, 3] * (RF[i].X - SF[sn].X)) * (RF[i].X - SF[sn].X)) * (RF[i].X - SF[sn].X);
                            }
                            break;
                        }
                }
            }
            LineItem l = ZGC.GraphPane.AddCurve("Требуемые точки", RF, Color.Red, SymbolType.XCross);
            l.Line.IsVisible = false;
            l = ZGC.GraphPane.AddCurve(null, SF, Color.Blue, SymbolType.XCross);
            l.Line.IsVisible = false;
            l = ZGC.GraphPane.AddCurve(SplineComboBox.SelectedIndex == 0 ? "Кубический сплайн" : "Сплайн Акимы", SFX, Color.Blue, SymbolType.None);
            l.Line.IsSmooth = true;
            RF.Sort(SortType.XValues);
            RF.RemoveAll(a => a.X < SF[0].X || a.X > SF.Last().X);
            RFDGV.Rows.Clear();
            RFDGV.RowCount = RF.Count + 1;
            for (int i = 0; i < RF.Count; i++) { RFDGV.Rows[i].Cells[0].Value = RF[i].X; RFDGV.Rows[i].Cells[1].Value = RF[i].Y; }
            l = ZGC.GraphPane.AddCurve(null, SF, Color.Blue, SymbolType.VDash);
            l.Line.IsVisible = false;
            ZGC.Invalidate();
        }

        private double[,] AkimaSpline(PointPairList DF)
        {
            int n = DF.Count + 4;
            double[] dx = new double[n], dy = new double[n], m = new double[n], t = new double[n], x = new double[n], y = new double[n];
            for (int i = 0; i < DF.Count; i++)
            {
                x[i + 2] = DF[i].X;
                y[i + 2] = DF[i].Y;
            }
            for (int i = 2; i < n - 3; i++)
            {
                dx[i] = x[i + 1] - x[i];
                dy[i] = y[i + 1] - y[i];
                m[i] = dy[i] / dx[i];
            }
            x[1] = x[2] + x[3] - x[4];
            dx[1] = x[2] - x[1];
            y[1] = dx[1] * (m[3] - 2 * m[2]) + y[2];
            dy[1] = y[2] - y[1];
            m[1] = dy[1] / dx[1];
            x[0] = 2 * x[2] - x[4];
            dx[0] = x[1] - x[0];
            y[0] = dx[0] * (m[2] - 2 * m[1]) + y[1];
            dy[0] = y[1] - y[0];
            m[0] = dy[0] / dx[0];
            x[n - 2] = x[n - 3] + x[n - 4] - x[n - 5];
            y[n - 2] = (2 * m[n - 4] - m[n - 5]) * (x[n - 2] - x[n - 3]) + y[n - 3];
            x[n - 1] = 2 * x[n - 3] - x[n - 5];
            y[n - 1] = (2 * m[n - 3] - m[n - 4]) * (x[n - 1] - x[n - 2]) + y[n - 2];
            for (int i = n - 3; i < n - 1; i++)
            {
                dx[i] = x[i + 1] - x[i]; dy[i] = y[i + 1] - y[i];
                m[i] = dy[i] / dx[i];
            }
            for (int i = 2; i < n - 2; i++)
            {
                double num, den;
                num = Math.Abs(m[i + 1] - m[i]) * m[i - 1] + Math.Abs(m[i - 1] - m[i - 2]) * m[i];
                den = Math.Abs(m[i + 1] - m[i]) + Math.Abs(m[i - 1] - m[i - 2]);
                if (den != 0) t[i] = num / den;
                else t[i] = 0;
            }
            double[,] ans = new double[DF.Count, 4];
            for (int i = 2; i < n - 2; i++)
            {
                ans[i - 2, 0] = y[i];
                ans[i - 2, 1] = t[i];
                ans[i - 2, 2] = (3 * m[i] - 2 * t[i] - t[i + 1]) / dx[i];
                ans[i - 2, 3] = (t[i] + t[i + 1] - 2 * m[i]) / (dx[i] * dx[i]);
            }
            return ans;
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            ReCalc();
            ZGC_ResetScale();
        }

        private void ZGC_DisplayCoords(ZedGraphControl ZGC, TextBox CPTB, TextBox PPTB)
        {
            Point p = ZGC.PointToClient(MousePosition);
            double x, y;
            ZGC.GraphPane.ReverseTransform(p, out x, out y);
            CurveItem crv;
            int n;
            ZGC.GraphPane.FindNearestPoint(new PointF(p.X, p.Y), out crv, out n);
            CPTB.Text = string.Format("({0:F3}; {1:F3})", x, y);
            if (crv != null) { PPTB.ForeColor = crv.Color; PPTB.Text = string.Format("({0:F3}; {1:F3})", crv[n].X, crv[n].Y); }
        }

        private void ZGC_ResetScale()
        {
            GraphPane G = ZGC.GraphPane;
            if (G.CurveList.Count > 0)
            {
                double Xmax = G.CurveList.Where(a => a.NPts > 0).Max(a => (a.Points as PointPairList).Max(b => b.X));
                double Xmin = G.CurveList.Where(a => a.NPts > 0).Min(a => (a.Points as PointPairList).Min(b => b.X));
                double Xind = (Xmax - Xmin) / 20; //X axis indent
                Xmax += Xind;
                Xmin -= Xind;
                G.XAxis.Scale.Max = Xmax;
                G.XAxis.Scale.Min = Xmin;
                double Ymax = G.CurveList.Where(a => a.NPts > 0).Max(a => (a.Points as PointPairList).Max(b => b.Y));
                double Ymin = G.CurveList.Where(a => a.NPts > 0).Min(a => (a.Points as PointPairList).Min(b => b.Y));
                double Yind = (Ymax - Ymin) / 20;
                Ymax += Yind;
                Ymin -= Yind;
                G.YAxis.Scale.Max = Ymax;
                G.YAxis.Scale.Min = Ymin;
                G.AxisChange();
                ZGC.Invalidate();
            }
        }

        private void ZGC_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            menuStrip.Items["copy"].Text = "Копировать";
            menuStrip.Items["page_setup"].Text = "Параметры страницы";
            menuStrip.Items["print"].Text = "Распечатать";
            menuStrip.Items["save_as"].Text = "Сохранить картинку как...";
            menuStrip.Items.RemoveByKey("set_default");
            menuStrip.Items.RemoveByKey("show_val");
            menuStrip.Items["unzoom"].Text = "Отменить масштабирование";
            menuStrip.Items["undo_all"].Text = "Общий вид";
            menuStrip.Items["undo_all"].Click += new EventHandler((object s, EventArgs e) => ZGC_ResetScale());
        }

        private void ShowCurrentCursorPositionOnGraph()
        {
            Point p = ZGC.PointToClient(MousePosition);
            CurveItem crv;
            int n;
            double x, y;
            ZGC.GraphPane.ReverseTransform(p, out x, out y);
            bool npf = ZGC.GraphPane.FindNearestPoint(new PointF(p.X, p.Y), out crv, out n);
            PointPositionTextBox.Text = npf ? string.Format("{0:F4}, {1:F4}", crv[n].X, crv[n].Y) : string.Empty;
            PointPositionTextBox.ForeColor = npf ? crv.Color : SystemColors.WindowText;
            CursorPositionTextBox.Text = string.Format("{0:F4}, {1:F4}", x, y);
        }

        private void SplineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            leftCondNUD.Enabled = rightCondNUD.Enabled = SplineComboBox.SelectedIndex == 0;
            ReCalc();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView DGV = this.ActiveControl as DataGridView;
            for (int i = 0; i < DGV.SelectedCells.Count; i++) if (!DGV.SelectedCells[i].ReadOnly) DGV.SelectedCells[i].Value = null;
        }

        private void DataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView DGV = sender as DataGridView;
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hti = DGV.HitTest(e.X, e.Y);
                if (hti.RowIndex >= 0)
                {
                    if (!DGV.Rows[hti.RowIndex].Cells[hti.ColumnIndex].Selected)
                    {
                        DGV.Select();
                        DGV.ClearSelection();
                        DGV.Rows[hti.RowIndex].Cells[hti.ColumnIndex].Selected = true;
                    }
                }
            }
        }
    }
}
