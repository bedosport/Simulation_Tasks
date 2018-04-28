namespace BearingMachineSimulation
{
    partial class Form1
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
            this.Num_of_hours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Num_of_bearings = new System.Windows.Forms.TextBox();
            this.number_of_bearings = new System.Windows.Forms.Label();
            this.Repair_Time_for_one_Bearing = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Repair_Time_for_all_bearings = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Bearing_cost = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Bearing_life = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumulative_Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Delay_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Probability2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumulative_probability2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Simulate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Repair_person_cost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.down_time_cost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Load = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // Num_of_hours
            // 
            this.Num_of_hours.Location = new System.Drawing.Point(740, 31);
            this.Num_of_hours.Name = "Num_of_hours";
            this.Num_of_hours.Size = new System.Drawing.Size(100, 20);
            this.Num_of_hours.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of hours";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Repair Time for one Bearing";
            // 
            // Num_of_bearings
            // 
            this.Num_of_bearings.Location = new System.Drawing.Point(740, 72);
            this.Num_of_bearings.Name = "Num_of_bearings";
            this.Num_of_bearings.Size = new System.Drawing.Size(100, 20);
            this.Num_of_bearings.TabIndex = 2;
            // 
            // number_of_bearings
            // 
            this.number_of_bearings.AutoSize = true;
            this.number_of_bearings.Location = new System.Drawing.Point(582, 79);
            this.number_of_bearings.Name = "number_of_bearings";
            this.number_of_bearings.Size = new System.Drawing.Size(99, 13);
            this.number_of_bearings.TabIndex = 5;
            this.number_of_bearings.Text = "Number of bearings";
            // 
            // Repair_Time_for_one_Bearing
            // 
            this.Repair_Time_for_one_Bearing.Location = new System.Drawing.Point(740, 113);
            this.Repair_Time_for_one_Bearing.Name = "Repair_Time_for_one_Bearing";
            this.Repair_Time_for_one_Bearing.Size = new System.Drawing.Size(100, 20);
            this.Repair_Time_for_one_Bearing.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(585, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Repair Time for all Bearings";
            // 
            // Repair_Time_for_all_bearings
            // 
            this.Repair_Time_for_all_bearings.Location = new System.Drawing.Point(740, 148);
            this.Repair_Time_for_all_bearings.Name = "Repair_Time_for_all_bearings";
            this.Repair_Time_for_all_bearings.Size = new System.Drawing.Size(100, 20);
            this.Repair_Time_for_all_bearings.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(585, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bearing Cost ";
            // 
            // Bearing_cost
            // 
            this.Bearing_cost.Location = new System.Drawing.Point(740, 186);
            this.Bearing_cost.Name = "Bearing_cost";
            this.Bearing_cost.Size = new System.Drawing.Size(100, 20);
            this.Bearing_cost.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bearing_life,
            this.Probability,
            this.cumulative_Probability,
            this.MIn,
            this.Max});
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(535, 202);
            this.dataGridView1.TabIndex = 10;
            // 
            // Bearing_life
            // 
            this.Bearing_life.HeaderText = "Bearing life";
            this.Bearing_life.Name = "Bearing_life";
            // 
            // Probability
            // 
            this.Probability.HeaderText = "Probability";
            this.Probability.Name = "Probability";
            // 
            // cumulative_Probability
            // 
            this.cumulative_Probability.HeaderText = "Cumulative Probability";
            this.cumulative_Probability.Name = "cumulative_Probability";
            // 
            // MIn
            // 
            this.MIn.HeaderText = "Min";
            this.MIn.Name = "MIn";
            // 
            // Max
            // 
            this.Max.HeaderText = "Max";
            this.Max.Name = "Max";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delay_time,
            this.Probability2,
            this.cumulative_probability2,
            this.Min2,
            this.Max2});
            this.dataGridView2.Location = new System.Drawing.Point(12, 300);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(535, 223);
            this.dataGridView2.TabIndex = 11;
            // 
            // Delay_time
            // 
            this.Delay_time.HeaderText = "Delay_time";
            this.Delay_time.Name = "Delay_time";
            // 
            // Probability2
            // 
            this.Probability2.HeaderText = "Probability";
            this.Probability2.Name = "Probability2";
            // 
            // cumulative_probability2
            // 
            this.cumulative_probability2.HeaderText = "Cumulative Probability ";
            this.cumulative_probability2.Name = "cumulative_probability2";
            // 
            // Min2
            // 
            this.Min2.HeaderText = "Min";
            this.Min2.Name = "Min2";
            // 
            // Max2
            // 
            this.Max2.HeaderText = "Max";
            this.Max2.Name = "Max2";
            // 
            // Simulate
            // 
            this.Simulate.Location = new System.Drawing.Point(629, 445);
            this.Simulate.Name = "Simulate";
            this.Simulate.Size = new System.Drawing.Size(168, 43);
            this.Simulate.TabIndex = 12;
            this.Simulate.Text = "simulate";
            this.Simulate.UseVisualStyleBackColor = true;
            this.Simulate.Click += new System.EventHandler(this.Simulate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(583, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Repair Person Cost";
            // 
            // Repair_person_cost
            // 
            this.Repair_person_cost.Location = new System.Drawing.Point(740, 225);
            this.Repair_person_cost.Name = "Repair_person_cost";
            this.Repair_person_cost.Size = new System.Drawing.Size(100, 20);
            this.Repair_person_cost.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Down time cost ";
            // 
            // down_time_cost
            // 
            this.down_time_cost.Location = new System.Drawing.Point(740, 262);
            this.down_time_cost.Name = "down_time_cost";
            this.down_time_cost.Size = new System.Drawing.Size(100, 20);
            this.down_time_cost.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Bearing Life Distribution";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Delay Time Distribution";
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(639, 363);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(146, 43);
            this.Load.TabIndex = 21;
            this.Load.Text = "Load Test";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TestCase1",
            "TestCase2",
            "TestCase3"});
            this.comboBox1.Location = new System.Drawing.Point(650, 336);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 553);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.down_time_cost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Repair_person_cost);
            this.Controls.Add(this.Simulate);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Bearing_cost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Repair_Time_for_all_bearings);
            this.Controls.Add(this.number_of_bearings);
            this.Controls.Add(this.Repair_Time_for_one_Bearing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Num_of_bearings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Num_of_hours);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Num_of_hours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Num_of_bearings;
        private System.Windows.Forms.Label number_of_bearings;
        private System.Windows.Forms.TextBox Repair_Time_for_one_Bearing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Repair_Time_for_all_bearings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Bearing_cost;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Probability2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cumulative_probability2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max2;
        private System.Windows.Forms.Button Simulate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Repair_person_cost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox down_time_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bearing_life;
        private System.Windows.Forms.DataGridViewTextBoxColumn Probability;
        private System.Windows.Forms.DataGridViewTextBoxColumn cumulative_Probability;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

