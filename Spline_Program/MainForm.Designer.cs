namespace Spline_Program
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RFDGV = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SDGV = new System.Windows.Forms.DataGridView();
            this.XColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ZGC = new ZedGraph.ZedGraphControl();
            this.leftCondNUD = new System.Windows.Forms.NumericUpDown();
            this.rightCondNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CursorPositionTextBox = new System.Windows.Forms.TextBox();
            this.PointPositionTextBox = new System.Windows.Forms.TextBox();
            this.CalcButton = new System.Windows.Forms.Button();
            this.SplineComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RFDGV)).BeginInit();
            this.DGVContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftCondNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightCondNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.RFDGV, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.SDGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ZGC, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftCondNUD, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.rightCondNUD, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CursorPositionTextBox, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.PointPositionTextBox, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.CalcButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.SplineComboBox, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 605);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RFDGV
            // 
            this.RFDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RFDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RFDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.RFDGV.ContextMenuStrip = this.DGVContextMenu;
            this.RFDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RFDGV.Location = new System.Drawing.Point(137, 25);
            this.RFDGV.Name = "RFDGV";
            this.RFDGV.RowHeadersVisible = false;
            this.RFDGV.RowHeadersWidth = 20;
            this.RFDGV.Size = new System.Drawing.Size(128, 527);
            this.RFDGV.TabIndex = 2;
            this.RFDGV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_MouseDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "X";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Y";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DGVContextMenu
            // 
            this.DGVContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PasteMenuItem,
            this.CopyMenuItem,
            this.deleteToolStripMenuItem});
            this.DGVContextMenu.Name = "CopyPasteMenuStrip";
            this.DGVContextMenu.Size = new System.Drawing.Size(182, 70);
            // 
            // PasteMenuItem
            // 
            this.PasteMenuItem.Name = "PasteMenuItem";
            this.PasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteMenuItem.Size = new System.Drawing.Size(181, 22);
            this.PasteMenuItem.Text = "Вставить";
            this.PasteMenuItem.Click += new System.EventHandler(this.PasteMenuItem_Click);
            // 
            // CopyMenuItem
            // 
            this.CopyMenuItem.Name = "CopyMenuItem";
            this.CopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyMenuItem.Size = new System.Drawing.Size(181, 22);
            this.CopyMenuItem.Text = "Копировать";
            this.CopyMenuItem.Click += new System.EventHandler(this.CopyMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // SDGV
            // 
            this.SDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XColumn,
            this.YColumn});
            this.SDGV.ContextMenuStrip = this.DGVContextMenu;
            this.SDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SDGV.Location = new System.Drawing.Point(3, 25);
            this.SDGV.Name = "SDGV";
            this.SDGV.RowHeadersVisible = false;
            this.SDGV.RowHeadersWidth = 20;
            this.SDGV.Size = new System.Drawing.Size(128, 527);
            this.SDGV.TabIndex = 0;
            this.SDGV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_MouseDown);
            // 
            // XColumn
            // 
            this.XColumn.HeaderText = "X";
            this.XColumn.Name = "XColumn";
            // 
            // YColumn
            // 
            this.YColumn.HeaderText = "Y";
            this.YColumn.Name = "YColumn";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Функция-источник";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Требуемые точки";
            // 
            // ZGC
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ZGC, 4);
            this.ZGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZGC.Location = new System.Drawing.Point(271, 3);
            this.ZGC.Name = "ZGC";
            this.tableLayoutPanel1.SetRowSpan(this.ZGC, 2);
            this.ZGC.ScrollGrace = 0D;
            this.ZGC.ScrollMaxX = 0D;
            this.ZGC.ScrollMaxY = 0D;
            this.ZGC.ScrollMaxY2 = 0D;
            this.ZGC.ScrollMinX = 0D;
            this.ZGC.ScrollMinY = 0D;
            this.ZGC.ScrollMinY2 = 0D;
            this.ZGC.Size = new System.Drawing.Size(510, 549);
            this.ZGC.TabIndex = 3;
            this.ZGC.UseExtendedPrintDialog = true;
            this.ZGC.ContextMenuBuilder += new ZedGraph.ZedGraphControl.ContextMenuBuilderEventHandler(this.ZGC_ContextMenuBuilder);
            // 
            // leftCondNUD
            // 
            this.leftCondNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftCondNUD.DecimalPlaces = 1;
            this.leftCondNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.leftCondNUD.Location = new System.Drawing.Point(57, 583);
            this.leftCondNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.leftCondNUD.Name = "leftCondNUD";
            this.leftCondNUD.Size = new System.Drawing.Size(74, 20);
            this.leftCondNUD.TabIndex = 8;
            // 
            // rightCondNUD
            // 
            this.rightCondNUD.DecimalPlaces = 1;
            this.rightCondNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rightCondNUD.Location = new System.Drawing.Point(137, 583);
            this.rightCondNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.rightCondNUD.Name = "rightCondNUD";
            this.rightCondNUD.Size = new System.Drawing.Size(74, 20);
            this.rightCondNUD.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Location = new System.Drawing.Point(56, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Краевые условия (значения y\'\')";
            // 
            // CursorPositionTextBox
            // 
            this.CursorPositionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.CursorPositionTextBox, 2);
            this.CursorPositionTextBox.Location = new System.Drawing.Point(529, 583);
            this.CursorPositionTextBox.Name = "CursorPositionTextBox";
            this.CursorPositionTextBox.Size = new System.Drawing.Size(252, 20);
            this.CursorPositionTextBox.TabIndex = 6;
            this.CursorPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PointPositionTextBox
            // 
            this.PointPositionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.PointPositionTextBox, 2);
            this.PointPositionTextBox.Location = new System.Drawing.Point(529, 558);
            this.PointPositionTextBox.Name = "PointPositionTextBox";
            this.PointPositionTextBox.Size = new System.Drawing.Size(252, 20);
            this.PointPositionTextBox.TabIndex = 6;
            this.PointPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CalcButton
            // 
            this.CalcButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CalcButton.AutoSize = true;
            this.CalcButton.Location = new System.Drawing.Point(414, 562);
            this.CalcButton.Name = "CalcButton";
            this.tableLayoutPanel1.SetRowSpan(this.CalcButton, 2);
            this.CalcButton.Size = new System.Drawing.Size(94, 35);
            this.CalcButton.TabIndex = 4;
            this.CalcButton.Text = "Расчет";
            this.CalcButton.UseVisualStyleBackColor = true;
            this.CalcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // SplineComboBox
            // 
            this.SplineComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SplineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SplineComboBox.FormattingEnabled = true;
            this.SplineComboBox.Items.AddRange(new object[] {
            "Кубический сплайн",
            "Сплайн Акимы"});
            this.SplineComboBox.Location = new System.Drawing.Point(272, 569);
            this.SplineComboBox.Name = "SplineComboBox";
            this.tableLayoutPanel1.SetRowSpan(this.SplineComboBox, 2);
            this.SplineComboBox.Size = new System.Drawing.Size(121, 22);
            this.SplineComboBox.TabIndex = 10;
            this.SplineComboBox.SelectedIndexChanged += new System.EventHandler(this.SplineComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 605);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(800, 643);
            this.Name = "MainForm";
            this.Text = "Сплайн-интерполяция";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RFDGV)).EndInit();
            this.DGVContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftCondNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightCondNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView SDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn XColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn YColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView RFDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip DGVContextMenu;
        private System.Windows.Forms.ToolStripMenuItem PasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyMenuItem;
        private ZedGraph.ZedGraphControl ZGC;
        private System.Windows.Forms.Button CalcButton;
        private System.Windows.Forms.TextBox CursorPositionTextBox;
        private System.Windows.Forms.NumericUpDown leftCondNUD;
        private System.Windows.Forms.NumericUpDown rightCondNUD;
        private System.Windows.Forms.TextBox PointPositionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SplineComboBox;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

