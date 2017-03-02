namespace SharpKernelUpdate
{
    partial class SharpKernelUpdateForm

    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.StableRelease = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // StableRelease
            // 
            this.StableRelease.AutoSize = true;
            this.StableRelease.Location = new System.Drawing.Point(637, 12);
            this.StableRelease.Name = "StableRelease";
            this.StableRelease.Size = new System.Drawing.Size(93, 17);
            this.StableRelease.TabIndex = 0;
            this.StableRelease.Text = "Stable release";
            this.StableRelease.UseVisualStyleBackColor = true;
            this.StableRelease.CheckedChanged += new System.EventHandler(this.stableRelease_CheckedChanged);
            // 
            // SharpKernelUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.StableRelease);
            this.Name = "SharpKernelUpdateForm";
            this.Text = "SharpKernelUpdateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox StableRelease;
    }
}

