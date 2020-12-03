namespace ZomatoParser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCuisines = new System.Windows.Forms.Button();
            this.btnRestaurants = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCuisines
            // 
            this.btnCuisines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCuisines.Location = new System.Drawing.Point(664, 54);
            this.btnCuisines.Name = "btnCuisines";
            this.btnCuisines.Size = new System.Drawing.Size(124, 36);
            this.btnCuisines.TabIndex = 2;
            this.btnCuisines.Text = "blet 2";
            this.btnCuisines.UseVisualStyleBackColor = true;
            this.btnCuisines.Click += new System.EventHandler(this.btnCuisines_Click);
            // 
            // btnRestaurants
            // 
            this.btnRestaurants.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurants.Location = new System.Drawing.Point(664, 12);
            this.btnRestaurants.Name = "btnRestaurants";
            this.btnRestaurants.Size = new System.Drawing.Size(124, 36);
            this.btnRestaurants.TabIndex = 1;
            this.btnRestaurants.Text = "blet 1";
            this.btnRestaurants.UseVisualStyleBackColor = true;
            this.btnRestaurants.Click += new System.EventHandler(this.btnRestaurants_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCuisines);
            this.Controls.Add(this.btnRestaurants);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Zomato";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCuisines;
        private System.Windows.Forms.Button btnRestaurants;
    }
}

