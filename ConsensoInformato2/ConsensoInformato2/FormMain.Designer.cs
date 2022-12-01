namespace ConsensoInformato2
{
    partial class FormMain
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lsbModelli = new System.Windows.Forms.ListBox();
            this.lsbSelezionati = new System.Windows.Forms.ListBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.grbFirma = new System.Windows.Forms.GroupBox();
            this.rdbTutore = new System.Windows.Forms.RadioButton();
            this.rdbMadre = new System.Windows.Forms.RadioButton();
            this.rdbPadre = new System.Windows.Forms.RadioButton();
            this.rdbPaziente = new System.Windows.Forms.RadioButton();
            this.lblPaziente = new System.Windows.Forms.Label();
            this.lblGenerating = new System.Windows.Forms.Label();
            this.lblMedico = new System.Windows.Forms.Label();
            this.pdfnNavigator = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.pdfvViewer = new ConsensoInformato2.UCPdfViewer();
            this.grbFirma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfnNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfvViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGenerate.Location = new System.Drawing.Point(822, 615);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(183, 41);
            this.cmdGenerate.TabIndex = 1;
            this.cmdGenerate.Text = "Genera";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(594, 615);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(183, 41);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Chiudi";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lsbModelli
            // 
            this.lsbModelli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbModelli.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbModelli.FormattingEnabled = true;
            this.lsbModelli.IntegralHeight = false;
            this.lsbModelli.ItemHeight = 16;
            this.lsbModelli.Location = new System.Drawing.Point(4, 32);
            this.lsbModelli.Name = "lsbModelli";
            this.lsbModelli.Size = new System.Drawing.Size(375, 321);
            this.lsbModelli.TabIndex = 3;
            // 
            // lsbSelezionati
            // 
            this.lsbSelezionati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbSelezionati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbSelezionati.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbSelezionati.FormattingEnabled = true;
            this.lsbSelezionati.IntegralHeight = false;
            this.lsbSelezionati.ItemHeight = 16;
            this.lsbSelezionati.Location = new System.Drawing.Point(2, 359);
            this.lsbSelezionati.Name = "lsbSelezionati";
            this.lsbSelezionati.Size = new System.Drawing.Size(375, 226);
            this.lsbSelezionati.TabIndex = 4;
            this.lsbSelezionati.SelectedIndexChanged += new System.EventHandler(this.lsbSelezionati_SelectedIndexChanged);
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.Color.White;
            this.cmdAdd.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdd.Image")));
            this.cmdAdd.Location = new System.Drawing.Point(340, 306);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(39, 47);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRemove.BackColor = System.Drawing.Color.White;
            this.cmdRemove.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemove.Image")));
            this.cmdRemove.Location = new System.Drawing.Point(338, 538);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(39, 47);
            this.cmdRemove.TabIndex = 6;
            this.cmdRemove.UseVisualStyleBackColor = false;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // grbFirma
            // 
            this.grbFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbFirma.Controls.Add(this.rdbTutore);
            this.grbFirma.Controls.Add(this.rdbMadre);
            this.grbFirma.Controls.Add(this.rdbPadre);
            this.grbFirma.Controls.Add(this.rdbPaziente);
            this.grbFirma.Location = new System.Drawing.Point(4, 589);
            this.grbFirma.Name = "grbFirma";
            this.grbFirma.Size = new System.Drawing.Size(375, 69);
            this.grbFirma.TabIndex = 8;
            this.grbFirma.TabStop = false;
            this.grbFirma.Text = "Firma";
            // 
            // rdbTutore
            // 
            this.rdbTutore.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbTutore.Location = new System.Drawing.Point(271, 23);
            this.rdbTutore.Name = "rdbTutore";
            this.rdbTutore.Size = new System.Drawing.Size(80, 30);
            this.rdbTutore.TabIndex = 3;
            this.rdbTutore.Text = "Tutore";
            this.rdbTutore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbTutore.UseVisualStyleBackColor = true;
            this.rdbTutore.CheckedChanged += new System.EventHandler(this.rdbChiFirma_CheckedChanged);
            // 
            // rdbMadre
            // 
            this.rdbMadre.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbMadre.Location = new System.Drawing.Point(103, 23);
            this.rdbMadre.Name = "rdbMadre";
            this.rdbMadre.Size = new System.Drawing.Size(80, 30);
            this.rdbMadre.TabIndex = 2;
            this.rdbMadre.Text = "Madre";
            this.rdbMadre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbMadre.UseVisualStyleBackColor = true;
            this.rdbMadre.CheckedChanged += new System.EventHandler(this.rdbChiFirma_CheckedChanged);
            // 
            // rdbPadre
            // 
            this.rdbPadre.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbPadre.Location = new System.Drawing.Point(187, 23);
            this.rdbPadre.Name = "rdbPadre";
            this.rdbPadre.Size = new System.Drawing.Size(80, 30);
            this.rdbPadre.TabIndex = 1;
            this.rdbPadre.Text = "Padre";
            this.rdbPadre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbPadre.UseVisualStyleBackColor = true;
            this.rdbPadre.CheckedChanged += new System.EventHandler(this.rdbChiFirma_CheckedChanged);
            // 
            // rdbPaziente
            // 
            this.rdbPaziente.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbPaziente.Checked = true;
            this.rdbPaziente.Location = new System.Drawing.Point(18, 23);
            this.rdbPaziente.Name = "rdbPaziente";
            this.rdbPaziente.Size = new System.Drawing.Size(80, 30);
            this.rdbPaziente.TabIndex = 0;
            this.rdbPaziente.TabStop = true;
            this.rdbPaziente.Text = "Paziente";
            this.rdbPaziente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbPaziente.UseVisualStyleBackColor = true;
            this.rdbPaziente.CheckedChanged += new System.EventHandler(this.rdbChiFirma_CheckedChanged);
            // 
            // lblPaziente
            // 
            this.lblPaziente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaziente.Location = new System.Drawing.Point(8, 4);
            this.lblPaziente.Name = "lblPaziente";
            this.lblPaziente.Size = new System.Drawing.Size(461, 23);
            this.lblPaziente.TabIndex = 10;
            this.lblPaziente.Text = "Paziente: ";
            this.lblPaziente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGenerating
            // 
            this.lblGenerating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenerating.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerating.Location = new System.Drawing.Point(385, 586);
            this.lblGenerating.Name = "lblGenerating";
            this.lblGenerating.Size = new System.Drawing.Size(642, 23);
            this.lblGenerating.TabIndex = 11;
            this.lblGenerating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMedico
            // 
            this.lblMedico.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedico.Location = new System.Drawing.Point(475, 4);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(552, 23);
            this.lblMedico.TabIndex = 14;
            this.lblMedico.Text = "Dottore: ";
            this.lblMedico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMedico.Click += new System.EventHandler(this.lblMedico_Click);
            // 
            // pdfnNavigator
            // 
            this.pdfnNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfnNavigator.AssociatedViewer = this.pdfvViewer;
            this.pdfnNavigator.Location = new System.Drawing.Point(385, 32);
            this.pdfnNavigator.Name = "pdfnNavigator";
            this.pdfnNavigator.Size = new System.Drawing.Size(642, 40);
            this.pdfnNavigator.TabIndex = 13;
            ((Telerik.WinControls.UI.CommandBarRowElement)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0))).MinSize = new System.Drawing.Size(25, 25);
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(34, 34);
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).SvgImage = ((Telerik.WinControls.RadSvgImage)(resources.GetObject("resource.SvgImage")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Text = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).ToolTipText = "Open";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).VisibleInStrip = false;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).SvgImage = ((Telerik.WinControls.RadSvgImage)(resources.GetObject("resource.SvgImage1")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Text = "Print";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).ToolTipText = "Print";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(2))).VisibleInStrip = false;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).VisibleInStrip = false;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).MinSize = new System.Drawing.Size(0, 0);
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).SvgImage = ((Telerik.WinControls.RadSvgImage)(resources.GetObject("resource.SvgImage2")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).Text = "Save As";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).ToolTipText = "Save As";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(3))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(4))).VisibleInStrip = false;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(4))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).VisibleInStrip = false;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).SvgImage = ((Telerik.WinControls.RadSvgImage)(resources.GetObject("resource.SvgImage3")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).Text = "Rotate Counterclockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).ToolTipText = "Rotate Counterclockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(5))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).VisibleInStrip = false;
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).SvgImage = ((Telerik.WinControls.RadSvgImage)(resources.GetObject("resource.SvgImage4")));
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).Text = "Rotate Clockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).ToolTipText = "Rotate Clockwise";
            ((Telerik.WinControls.UI.CommandBarButton)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(6))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.CommandBarSeparator)(this.pdfnNavigator.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(7))).VisibleInStrip = false;
            // 
            // pdfvViewer
            // 
            this.pdfvViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfvViewer.EnableThumbnails = false;
            this.pdfvViewer.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfvViewer.Location = new System.Drawing.Point(385, 76);
            this.pdfvViewer.Name = "pdfvViewer";
            this.pdfvViewer.Size = new System.Drawing.Size(642, 509);
            this.pdfvViewer.TabIndex = 12;
            this.pdfvViewer.ThumbnailsScaleFactor = 0.15F;
            this.pdfvViewer.DocumentLoaded += new System.EventHandler(this.pdfvViewer_DocumentLoaded);
            ((Telerik.WinControls.UI.RadPdfViewerContainer)(this.pdfvViewer.GetChildAt(0))).MinimumThumbWidth = 34;
            ((Telerik.WinControls.UI.RadPdfViewerContainer)(this.pdfvViewer.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.ThumbnailListElement)(this.pdfvViewer.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.ThumbnailListHeaderElement)(this.pdfvViewer.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.RadPdfViewerElement)(this.pdfvViewer.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
            ((Telerik.WinControls.UI.PdfSizeGripElement)(this.pdfvViewer.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1034, 664);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.pdfnNavigator);
            this.Controls.Add(this.pdfvViewer);
            this.Controls.Add(this.lblGenerating);
            this.Controls.Add(this.lblPaziente);
            this.Controls.Add(this.grbFirma);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.lsbSelezionati);
            this.Controls.Add(this.lsbModelli);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.grbFirma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfnNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfvViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ListBox lsbModelli;
        private System.Windows.Forms.ListBox lsbSelezionati;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.GroupBox grbFirma;
        private System.Windows.Forms.RadioButton rdbTutore;
        private System.Windows.Forms.RadioButton rdbMadre;
        private System.Windows.Forms.RadioButton rdbPadre;
        private System.Windows.Forms.RadioButton rdbPaziente;
        private System.Windows.Forms.Label lblPaziente;
        private System.Windows.Forms.Label lblGenerating;
        private UCPdfViewer pdfvViewer;
        private Telerik.WinControls.UI.RadPdfViewerNavigator pdfnNavigator;
        private System.Windows.Forms.Label lblMedico;
    }
}

