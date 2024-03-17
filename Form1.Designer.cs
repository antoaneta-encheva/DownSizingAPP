namespace DownSizingAPP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            DownSizeParallelBtn = new Button();
            DownSizeBtn = new Button();
            ScalingInput = new TextBox();
            panel2 = new Panel();
            StatusLabel = new Label();
            label5 = new Label();
            ClearImgBtn = new Button();
            SelectImgBtn = new Button();
            NormalDowmSizePictureBox = new PictureBox();
            ParallelDownSizePictureBox = new PictureBox();
            label1 = new Label();
            TimeStandart = new Label();
            label2 = new Label();
            TimeParallel = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NormalDowmSizePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ParallelDownSizePictureBox).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(DownSizeParallelBtn);
            panel1.Controls.Add(DownSizeBtn);
            panel1.Controls.Add(ScalingInput);
            panel1.Location = new Point(11, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(342, 95);
            panel1.TabIndex = 0;
            // 
            // DownSizeParallelBtn
            // 
            DownSizeParallelBtn.Location = new Point(177, 44);
            DownSizeParallelBtn.Name = "DownSizeParallel";
            DownSizeParallelBtn.Size = new Size(140, 40);
            DownSizeParallelBtn.TabIndex = 2;
            DownSizeParallelBtn.Text = "Scale Parallel";
            DownSizeParallelBtn.UseVisualStyleBackColor = true;
            DownSizeParallelBtn.Click += DownSizeParallel_Click;
            // 
            // DownSizeBtn
            // 
            DownSizeBtn.Location = new Point(6, 45);
            DownSizeBtn.Name = "DownSizeBtn";
            DownSizeBtn.Size = new Size(140, 40);
            DownSizeBtn.TabIndex = 1;
            DownSizeBtn.Text = "Scale";
            DownSizeBtn.UseVisualStyleBackColor = true;
            DownSizeBtn.Click += DownSizeBtn_Click;
            // 
            // ScalingInput
            // 
            ScalingInput.Location = new Point(6, 11);
            ScalingInput.Name = "ScalingInput";
            ScalingInput.Size = new Size(311, 27);
            ScalingInput.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(StatusLabel);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(ClearImgBtn);
            panel2.Controls.Add(SelectImgBtn);
            panel2.Location = new Point(359, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(339, 95);
            panel2.TabIndex = 1;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(130, 66);
            StatusLabel.Name = "statusLabel";
            StatusLabel.Size = new Size(0, 20);
            StatusLabel.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 65);
            label5.Name = "label5";
            label5.Size = new Size(126, 20);
            label5.TabIndex = 2;
            label5.Text = "Processing Status:";
            // 
            // ClearImgBtn
            // 
            ClearImgBtn.Location = new Point(163, 13);
            ClearImgBtn.Name = "ClearImg";
            ClearImgBtn.Size = new Size(140, 40);
            ClearImgBtn.TabIndex = 1;
            ClearImgBtn.Text = "Remove Image";
            ClearImgBtn.UseVisualStyleBackColor = true;
            ClearImgBtn.Click += ClearImg_Click;
            // 
            // SelectImgBtn
            // 
            SelectImgBtn.Location = new Point(9, 13);
            SelectImgBtn.Name = "SelectImg";
            SelectImgBtn.Size = new Size(140, 40);
            SelectImgBtn.TabIndex = 0;
            SelectImgBtn.Text = "Select Image";
            SelectImgBtn.UseVisualStyleBackColor = true;
            SelectImgBtn.Click += SelectImg_Click;
            // 
            // NormalDowmSizePictureBox
            // 
            NormalDowmSizePictureBox.Location = new Point(8, 106);
            NormalDowmSizePictureBox.Name = "normalDowmSizePictureBox";
            NormalDowmSizePictureBox.Size = new Size(480, 390);
            NormalDowmSizePictureBox.TabIndex = 2;
            NormalDowmSizePictureBox.TabStop = false;
            // 
            // ParallelDownSizePictureBox
            // 
            ParallelDownSizePictureBox.Location = new Point(493, 106);
            ParallelDownSizePictureBox.Name = "parallelDownSizePictureBox";
            ParallelDownSizePictureBox.Size = new Size(480, 390);
            ParallelDownSizePictureBox.TabIndex = 3;
            ParallelDownSizePictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 4;
            label1.Text = "Time standart scale:";
            // 
            // TimeStandart
            // 
            TimeStandart.AutoSize = true;
            TimeStandart.Location = new Point(163, 18);
            TimeStandart.Name = "timeNoParallel";
            TimeStandart.Size = new Size(17, 20);
            TimeStandart.TabIndex = 5;
            TimeStandart.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 53);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 6;
            label2.Text = "Time Parallel:";
            // 
            // TimeParallel
            // 
            TimeParallel.AutoSize = true;
            TimeParallel.Location = new Point(163, 56);
            TimeParallel.Name = "TimeParallel";
            TimeParallel.Size = new Size(17, 20);
            TimeParallel.TabIndex = 7;
            TimeParallel.Text = "0";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(TimeParallel);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(TimeStandart);
            panel3.Location = new Point(704, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(265, 95);
            panel3.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 505);
            Controls.Add(panel3);
            Controls.Add(ParallelDownSizePictureBox);
            Controls.Add(NormalDowmSizePictureBox);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Image Resizer";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NormalDowmSizePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ParallelDownSizePictureBox).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button DownSizeBtn;
        private TextBox ScalingInput;
        private Panel panel2;
        private PictureBox NormalDowmSizePictureBox;
        private Button SelectImgBtn;
        private Button DownSizeParallelBtn;
        private PictureBox ParallelDownSizePictureBox;
        private Label label1;
        private Label TimeStandart;
        private Label label2;
        private Label TimeParallel;
        private Button ClearImgBtn;
        private Panel panel3;
        private Label StatusLabel;
        private Label label5;
    }
}
