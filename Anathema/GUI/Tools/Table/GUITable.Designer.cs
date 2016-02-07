﻿namespace Anathema
{
    partial class GUITable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUITable));
            this.CheatTableSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ScanToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveTableButton = new System.Windows.Forms.ToolStripButton();
            this.LoadTableButton = new System.Windows.Forms.ToolStripButton();
            this.AddAddressButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CheatTableButton = new System.Windows.Forms.ToolStripButton();
            this.FSMTableButton = new System.Windows.Forms.ToolStripButton();
            this.GUIAddressTable = new Anathema.GUIAddressTable();
            this.GUIScriptTable = new Anathema.GUIScriptTable();
            this.FSMTableListView = new Anathema.FlickerFreeListView();
            this.FSMDescriptionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.CheatTableSplitContainer)).BeginInit();
            this.CheatTableSplitContainer.Panel1.SuspendLayout();
            this.CheatTableSplitContainer.Panel2.SuspendLayout();
            this.CheatTableSplitContainer.SuspendLayout();
            this.ScanToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheatTableSplitContainer
            // 
            this.CheatTableSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheatTableSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.CheatTableSplitContainer.Name = "CheatTableSplitContainer";
            // 
            // CheatTableSplitContainer.Panel1
            // 
            this.CheatTableSplitContainer.Panel1.Controls.Add(this.GUIAddressTable);
            // 
            // CheatTableSplitContainer.Panel2
            // 
            this.CheatTableSplitContainer.Panel2.Controls.Add(this.GUIScriptTable);
            this.CheatTableSplitContainer.Size = new System.Drawing.Size(698, 225);
            this.CheatTableSplitContainer.SplitterDistance = 467;
            this.CheatTableSplitContainer.TabIndex = 145;
            // 
            // ScanToolStrip
            // 
            this.ScanToolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.ScanToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ScanToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveTableButton,
            this.LoadTableButton,
            this.AddAddressButton,
            this.ToolStripSeparator1,
            this.CheatTableButton,
            this.FSMTableButton});
            this.ScanToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.ScanToolStrip.Location = new System.Drawing.Point(698, 0);
            this.ScanToolStrip.Name = "ScanToolStrip";
            this.ScanToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ScanToolStrip.Size = new System.Drawing.Size(24, 225);
            this.ScanToolStrip.TabIndex = 150;
            // 
            // SaveTableButton
            // 
            this.SaveTableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveTableButton.Image = global::Anathema.Properties.Resources.Save;
            this.SaveTableButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveTableButton.Name = "SaveTableButton";
            this.SaveTableButton.Size = new System.Drawing.Size(21, 20);
            this.SaveTableButton.Text = "Save Table";
            this.SaveTableButton.Click += new System.EventHandler(this.SaveTableButton_Click);
            // 
            // LoadTableButton
            // 
            this.LoadTableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadTableButton.Image = global::Anathema.Properties.Resources.Open;
            this.LoadTableButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadTableButton.Name = "LoadTableButton";
            this.LoadTableButton.Size = new System.Drawing.Size(21, 20);
            this.LoadTableButton.Text = "Open Table";
            this.LoadTableButton.ToolTipText = "Open Table";
            this.LoadTableButton.Click += new System.EventHandler(this.LoadTableButton_Click);
            // 
            // AddAddressButton
            // 
            this.AddAddressButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddAddressButton.Image = global::Anathema.Properties.Resources.Increased;
            this.AddAddressButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddAddressButton.Name = "AddAddressButton";
            this.AddAddressButton.Size = new System.Drawing.Size(21, 20);
            this.AddAddressButton.Text = "Add Address Manually";
            this.AddAddressButton.Click += new System.EventHandler(this.AddAddressButton_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(21, 6);
            // 
            // CheatTableButton
            // 
            this.CheatTableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CheatTableButton.Image = global::Anathema.Properties.Resources.BenedictionIcon;
            this.CheatTableButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheatTableButton.Name = "CheatTableButton";
            this.CheatTableButton.Size = new System.Drawing.Size(21, 20);
            this.CheatTableButton.Text = "Cheat Table";
            this.CheatTableButton.Click += new System.EventHandler(this.CheatTableButton_Click);
            // 
            // FSMTableButton
            // 
            this.FSMTableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FSMTableButton.Image = global::Anathema.Properties.Resources.CelestialIcon;
            this.FSMTableButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FSMTableButton.Name = "FSMTableButton";
            this.FSMTableButton.Size = new System.Drawing.Size(21, 20);
            this.FSMTableButton.Text = "FSM Table";
            this.FSMTableButton.Click += new System.EventHandler(this.FSMTableButton_Click);
            // 
            // GUIAddressTable
            // 
            this.GUIAddressTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GUIAddressTable.Location = new System.Drawing.Point(0, 0);
            this.GUIAddressTable.Name = "GUIAddressTable";
            this.GUIAddressTable.Size = new System.Drawing.Size(467, 225);
            this.GUIAddressTable.TabIndex = 0;
            // 
            // GUIScriptTable
            // 
            this.GUIScriptTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GUIScriptTable.Location = new System.Drawing.Point(0, 0);
            this.GUIScriptTable.Name = "GUIScriptTable";
            this.GUIScriptTable.Size = new System.Drawing.Size(227, 225);
            this.GUIScriptTable.TabIndex = 0;
            // 
            // FSMTableListView
            // 
            this.FSMTableListView.BackColor = System.Drawing.SystemColors.Control;
            this.FSMTableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FSMDescriptionHeader});
            this.FSMTableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FSMTableListView.Location = new System.Drawing.Point(0, 0);
            this.FSMTableListView.Name = "FSMTableListView";
            this.FSMTableListView.Size = new System.Drawing.Size(722, 225);
            this.FSMTableListView.TabIndex = 151;
            this.FSMTableListView.UseCompatibleStateImageBehavior = false;
            this.FSMTableListView.View = System.Windows.Forms.View.Details;
            this.FSMTableListView.VirtualMode = true;
            // 
            // FSMDescriptionHeader
            // 
            this.FSMDescriptionHeader.Text = "Description";
            this.FSMDescriptionHeader.Width = 663;
            // 
            // GUITable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 225);
            this.Controls.Add(this.CheatTableSplitContainer);
            this.Controls.Add(this.ScanToolStrip);
            this.Controls.Add(this.FSMTableListView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUITable";
            this.Text = "Table";
            this.CheatTableSplitContainer.Panel1.ResumeLayout(false);
            this.CheatTableSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheatTableSplitContainer)).EndInit();
            this.CheatTableSplitContainer.ResumeLayout(false);
            this.ScanToolStrip.ResumeLayout(false);
            this.ScanToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer CheatTableSplitContainer;
        private System.Windows.Forms.ToolStrip ScanToolStrip;
        private System.Windows.Forms.ToolStripButton SaveTableButton;
        private System.Windows.Forms.ToolStripButton LoadTableButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CheatTableButton;
        private System.Windows.Forms.ToolStripButton FSMTableButton;
        private FlickerFreeListView FSMTableListView;
        private System.Windows.Forms.ColumnHeader FSMDescriptionHeader;
        private System.Windows.Forms.ToolStripButton AddAddressButton;
        private GUIAddressTable GUIAddressTable;
        private GUIScriptTable GUIScriptTable;
    }
}