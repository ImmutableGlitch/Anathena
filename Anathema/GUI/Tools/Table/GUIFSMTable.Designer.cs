﻿namespace Anathema
{
    partial class GUIFSMTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FSMTableListView = new Anathema.FlickerFreeListView();
            this.FSMDescriptionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // FSMTableListView
            // 
            this.FSMTableListView.BackColor = System.Drawing.SystemColors.Control;
            this.FSMTableListView.CheckBoxes = true;
            this.FSMTableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FSMDescriptionHeader});
            this.FSMTableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FSMTableListView.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSMTableListView.FullRowSelect = true;
            this.FSMTableListView.Location = new System.Drawing.Point(0, 0);
            this.FSMTableListView.Name = "FSMTableListView";
            this.FSMTableListView.OwnerDraw = true;
            this.FSMTableListView.ShowGroups = false;
            this.FSMTableListView.Size = new System.Drawing.Size(222, 200);
            this.FSMTableListView.TabIndex = 145;
            this.FSMTableListView.UseCompatibleStateImageBehavior = false;
            this.FSMTableListView.View = System.Windows.Forms.View.Details;
            this.FSMTableListView.VirtualMode = true;
            // 
            // FSMDescriptionHeader
            // 
            this.FSMDescriptionHeader.Text = "Description";
            this.FSMDescriptionHeader.Width = 212;
            // 
            // GUIFSMTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FSMTableListView);
            this.Name = "GUIFSMTable";
            this.Size = new System.Drawing.Size(222, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private FlickerFreeListView FSMTableListView;
        private System.Windows.Forms.ColumnHeader FSMDescriptionHeader;
    }
}
