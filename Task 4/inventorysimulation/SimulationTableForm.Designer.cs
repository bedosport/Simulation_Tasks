namespace InventorySimulation
{
    partial class SimulationTableForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayWithinCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginningInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomDigitsDemand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndingInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomDigitsLead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.AverageEnding = new System.Windows.Forms.TextBox();
            this.AverageShortage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.Cycle,
            this.DayWithinCycle,
            this.BeginningInventory,
            this.RandomDigitsDemand,
            this.Demand,
            this.EndingInventory,
            this.ShortageQuantity,
            this.OrderQuantity,
            this.RandomDigitsLead,
            this.LeadDays});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(978, 421);
            this.dataGridView1.TabIndex = 0;
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            this.Day.Width = 50;
            // 
            // Cycle
            // 
            this.Cycle.HeaderText = "Cycle";
            this.Cycle.Name = "Cycle";
            this.Cycle.ReadOnly = true;
            this.Cycle.Width = 50;
            // 
            // DayWithinCycle
            // 
            this.DayWithinCycle.HeaderText = "Day Within Cycle";
            this.DayWithinCycle.Name = "DayWithinCycle";
            this.DayWithinCycle.ReadOnly = true;
            this.DayWithinCycle.Width = 50;
            // 
            // BeginningInventory
            // 
            this.BeginningInventory.HeaderText = "Beginning Inventory";
            this.BeginningInventory.Name = "BeginningInventory";
            this.BeginningInventory.ReadOnly = true;
            // 
            // RandomDigitsDemand
            // 
            this.RandomDigitsDemand.HeaderText = "Random Digits for Demand";
            this.RandomDigitsDemand.Name = "RandomDigitsDemand";
            this.RandomDigitsDemand.ReadOnly = true;
            // 
            // Demand
            // 
            this.Demand.HeaderText = "Demand";
            this.Demand.Name = "Demand";
            this.Demand.ReadOnly = true;
            // 
            // EndingInventory
            // 
            this.EndingInventory.HeaderText = "Ending Inventory";
            this.EndingInventory.Name = "EndingInventory";
            this.EndingInventory.ReadOnly = true;
            // 
            // ShortageQuantity
            // 
            this.ShortageQuantity.HeaderText = "Shortage Quantity";
            this.ShortageQuantity.Name = "ShortageQuantity";
            this.ShortageQuantity.ReadOnly = true;
            // 
            // OrderQuantity
            // 
            this.OrderQuantity.HeaderText = "Order Quantity";
            this.OrderQuantity.Name = "OrderQuantity";
            this.OrderQuantity.ReadOnly = true;
            // 
            // RandomDigitsLead
            // 
            this.RandomDigitsLead.HeaderText = "Random Digits for Lead Time";
            this.RandomDigitsLead.Name = "RandomDigitsLead";
            this.RandomDigitsLead.ReadOnly = true;
            // 
            // LeadDays
            // 
            this.LeadDays.HeaderText = "Lead Time";
            this.LeadDays.Name = "LeadDays";
            this.LeadDays.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Performance Measures";
            // 
            // AverageEnding
            // 
            this.AverageEnding.Location = new System.Drawing.Point(240, 497);
            this.AverageEnding.Name = "AverageEnding";
            this.AverageEnding.ReadOnly = true;
            this.AverageEnding.Size = new System.Drawing.Size(100, 20);
            this.AverageEnding.TabIndex = 2;
            // 
            // AverageShortage
            // 
            this.AverageShortage.Location = new System.Drawing.Point(703, 497);
            this.AverageShortage.Name = "AverageShortage";
            this.AverageShortage.ReadOnly = true;
            this.AverageShortage.Size = new System.Drawing.Size(100, 20);
            this.AverageShortage.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Average Ending";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Average Shortage";
            // 
            // SimulationTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 548);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AverageShortage);
            this.Controls.Add(this.AverageEnding);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SimulationTableForm";
            this.Text = "Simulation Table";
            this.Load += new System.EventHandler(this.SimulationTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayWithinCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginningInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomDigitsDemand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndingInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortageQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomDigitsLead;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AverageEnding;
        private System.Windows.Forms.TextBox AverageShortage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}