namespace Lab_1
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
            this.initialPictureBox = new System.Windows.Forms.PictureBox();
            this.transformedPictureBox = new System.Windows.Forms.PictureBox();
            this.labelImagineTransformata = new System.Windows.Forms.Label();
            this.labelImagineInitiala = new System.Windows.Forms.Label();
            this.buttonOpenImage = new System.Windows.Forms.Button();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonMakeInitial = new System.Windows.Forms.Button();
            this.buttonDeterminareContur = new System.Windows.Forms.Button();
            this.buttonDeterminareSchelet = new System.Windows.Forms.Button();
            this.buttonSubtiere = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.initialPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // initialPictureBox
            // 
            this.initialPictureBox.Location = new System.Drawing.Point(12, 66);
            this.initialPictureBox.Name = "initialPictureBox";
            this.initialPictureBox.Size = new System.Drawing.Size(427, 485);
            this.initialPictureBox.TabIndex = 0;
            this.initialPictureBox.TabStop = false;
            // 
            // transformedPictureBox
            // 
            this.transformedPictureBox.Location = new System.Drawing.Point(659, 66);
            this.transformedPictureBox.Name = "transformedPictureBox";
            this.transformedPictureBox.Size = new System.Drawing.Size(427, 485);
            this.transformedPictureBox.TabIndex = 1;
            this.transformedPictureBox.TabStop = false;
            // 
            // labelImagineTransformata
            // 
            this.labelImagineTransformata.AutoSize = true;
            this.labelImagineTransformata.Location = new System.Drawing.Point(656, 46);
            this.labelImagineTransformata.Name = "labelImagineTransformata";
            this.labelImagineTransformata.Size = new System.Drawing.Size(141, 17);
            this.labelImagineTransformata.TabIndex = 2;
            this.labelImagineTransformata.Text = "Imagine transformata";
            // 
            // labelImagineInitiala
            // 
            this.labelImagineInitiala.AutoSize = true;
            this.labelImagineInitiala.Location = new System.Drawing.Point(9, 46);
            this.labelImagineInitiala.Name = "labelImagineInitiala";
            this.labelImagineInitiala.Size = new System.Drawing.Size(101, 17);
            this.labelImagineInitiala.TabIndex = 2;
            this.labelImagineInitiala.Text = "Imagine initiala";
            // 
            // buttonOpenImage
            // 
            this.buttonOpenImage.Location = new System.Drawing.Point(12, 558);
            this.buttonOpenImage.Name = "buttonOpenImage";
            this.buttonOpenImage.Size = new System.Drawing.Size(427, 43);
            this.buttonOpenImage.TabIndex = 3;
            this.buttonOpenImage.Text = "Open image";
            this.buttonOpenImage.UseVisualStyleBackColor = true;
            this.buttonOpenImage.Click += new System.EventHandler(this.buttonOpenImage_Click);
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(659, 558);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(427, 43);
            this.buttonSaveImage.TabIndex = 3;
            this.buttonSaveImage.Text = "Save image";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonMakeInitial
            // 
            this.buttonMakeInitial.Location = new System.Drawing.Point(446, 506);
            this.buttonMakeInitial.Name = "buttonMakeInitial";
            this.buttonMakeInitial.Size = new System.Drawing.Size(211, 45);
            this.buttonMakeInitial.TabIndex = 5;
            this.buttonMakeInitial.Text = "<- Make initial <-";
            this.buttonMakeInitial.UseVisualStyleBackColor = true;
            this.buttonMakeInitial.Click += new System.EventHandler(this.buttonMakeInitial_Click);
            // 
            // buttonDeterminareContur
            // 
            this.buttonDeterminareContur.Location = new System.Drawing.Point(446, 110);
            this.buttonDeterminareContur.Name = "buttonDeterminareContur";
            this.buttonDeterminareContur.Size = new System.Drawing.Size(207, 49);
            this.buttonDeterminareContur.TabIndex = 6;
            this.buttonDeterminareContur.Text = "Determinare contur";
            this.buttonDeterminareContur.UseVisualStyleBackColor = true;
            this.buttonDeterminareContur.Click += new System.EventHandler(this.buttonDeterminareContur_Click);
            // 
            // buttonDeterminareSchelet
            // 
            this.buttonDeterminareSchelet.Location = new System.Drawing.Point(446, 214);
            this.buttonDeterminareSchelet.Name = "buttonDeterminareSchelet";
            this.buttonDeterminareSchelet.Size = new System.Drawing.Size(207, 49);
            this.buttonDeterminareSchelet.TabIndex = 9;
            this.buttonDeterminareSchelet.Text = "Determinare schelet";
            this.buttonDeterminareSchelet.UseVisualStyleBackColor = true;
            this.buttonDeterminareSchelet.Click += new System.EventHandler(this.buttonDeterminareSchelet_Click);
            // 
            // buttonSubtiere
            // 
            this.buttonSubtiere.Location = new System.Drawing.Point(448, 319);
            this.buttonSubtiere.Name = "buttonSubtiere";
            this.buttonSubtiere.Size = new System.Drawing.Size(205, 49);
            this.buttonSubtiere.TabIndex = 10;
            this.buttonSubtiere.Text = "Subtiere";
            this.buttonSubtiere.UseVisualStyleBackColor = true;
            this.buttonSubtiere.Click += new System.EventHandler(this.buttonSubtiere_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 637);
            this.Controls.Add(this.buttonSubtiere);
            this.Controls.Add(this.buttonDeterminareSchelet);
            this.Controls.Add(this.buttonDeterminareContur);
            this.Controls.Add(this.buttonMakeInitial);
            this.Controls.Add(this.buttonSaveImage);
            this.Controls.Add(this.buttonOpenImage);
            this.Controls.Add(this.labelImagineInitiala);
            this.Controls.Add(this.labelImagineTransformata);
            this.Controls.Add(this.transformedPictureBox);
            this.Controls.Add(this.initialPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.initialPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox initialPictureBox;
        private System.Windows.Forms.PictureBox transformedPictureBox;
        private System.Windows.Forms.Label labelImagineTransformata;
        private System.Windows.Forms.Label labelImagineInitiala;
        private System.Windows.Forms.Button buttonOpenImage;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button buttonMakeInitial;
        private System.Windows.Forms.Button buttonDeterminareContur;
        private System.Windows.Forms.Button buttonDeterminareSchelet;
        private System.Windows.Forms.Button buttonSubtiere;
    }
}

