namespace PKDSS.MonoApp
{
    partial class EntryFrm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TimerFile = new System.Windows.Forms.Timer(this.components);
            this.tabScanning = new System.Windows.Forms.TabPage();
            this.chartWave = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnReset = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnBackground = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.imgOptical = new System.Windows.Forms.PictureBox();
            this.imgResolution = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbGuide = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbResolution = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cbObticalGian = new System.Windows.Forms.ComboBox();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.lbOpticalGian = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TxtDeviceStat = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabDataUnsur = new System.Windows.Forms.TabPage();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.WBC = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel59 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtWBC = new Bunifu.Framework.BunifuCustomTextbox();
            this.SILT = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel38 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtSILT = new Bunifu.Framework.BunifuCustomTextbox();
            this.SAND = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel40 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtSAND = new Bunifu.Framework.BunifuCustomTextbox();
            this.CLAY = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel39 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtCLAY = new Bunifu.Framework.BunifuCustomTextbox();
            this.KB_adjusted = new System.Windows.Forms.Panel();
            this.TxtKB_adjusted = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel36 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.KTK = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel47 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtKTK = new Bunifu.Framework.BunifuCustomTextbox();
            this.Na = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel34 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtNa = new Bunifu.Framework.BunifuCustomTextbox();
            this.K = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel48 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtK = new Bunifu.Framework.BunifuCustomTextbox();
            this.Mg = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel44 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtMg = new Bunifu.Framework.BunifuCustomTextbox();
            this.Ca = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel46 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtCa = new Bunifu.Framework.BunifuCustomTextbox();
            this.Bray1_P2O5 = new System.Windows.Forms.Panel();
            this.TxtBray1_P2O5 = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel45 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Olsen_P2O5 = new System.Windows.Forms.Panel();
            this.TxtOlsen_P2O5 = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel43 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.HCl25_K2O = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel52 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtHCl25_K2O = new Bunifu.Framework.BunifuCustomTextbox();
            this.HCl25_P2O5 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel42 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtHCl25_P2O5 = new Bunifu.Framework.BunifuCustomTextbox();
            this.KJELDAHL_N = new System.Windows.Forms.Panel();
            this.TxtKJELDAHL_N = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel49 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.PH_KCL = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel28 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtPH_KCL = new Bunifu.Framework.BunifuCustomTextbox();
            this.PH_H2O = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel53 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TxtPH_H2O = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnConfigUser = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel41 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tabInfoLokasi = new System.Windows.Forms.TabPage();
            this.bunifuCustomLabel22 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtBalitTanah = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel18 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtSample = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel17 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtHorizon = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel16 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cbKabupaten = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel15 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cbProvinsi = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel14 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel13 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtY = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel12 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbInisial = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtX = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel11 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtKecamatan = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtPengirim = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtDesa = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtNoTanah = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTahun = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtMappingUnit = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtNoObs = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtNoForm = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabRekomendasiPupuk = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel21 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtUrea = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel20 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtSP36 = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel19 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtKCL = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel60 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel62 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel61 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlNpk15 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel66 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtNpk15 = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel64 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlUrea15 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel65 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtUrea15 = new Bunifu.Framework.BunifuCustomTextbox();
            this.bunifuCustomLabel63 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel68 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel67 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbKomoditas = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.cbKomoditas = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel24 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabExportData = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearDB = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgUnsur = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dateUntil = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnResetFilter = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel25 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel27 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnSync = new System.Windows.Forms.Button();
            this.tabScanning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWave)).BeginInit();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).BeginInit();
            this.pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOptical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResolution)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabDataUnsur.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.WBC.SuspendLayout();
            this.SILT.SuspendLayout();
            this.SAND.SuspendLayout();
            this.CLAY.SuspendLayout();
            this.KB_adjusted.SuspendLayout();
            this.KTK.SuspendLayout();
            this.Na.SuspendLayout();
            this.K.SuspendLayout();
            this.Mg.SuspendLayout();
            this.Ca.SuspendLayout();
            this.Bray1_P2O5.SuspendLayout();
            this.Olsen_P2O5.SuspendLayout();
            this.HCl25_K2O.SuspendLayout();
            this.HCl25_P2O5.SuspendLayout();
            this.KJELDAHL_N.SuspendLayout();
            this.PH_KCL.SuspendLayout();
            this.PH_H2O.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfigUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabInfoLokasi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabRekomendasiPupuk.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlNpk15.SuspendLayout();
            this.pnlUrea15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabExportData.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUnsur)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResetFilter)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerFile
            // 
            this.TimerFile.Interval = 2000;
            // 
            // tabScanning
            // 
            this.tabScanning.BackColor = System.Drawing.Color.Transparent;
            this.tabScanning.Controls.Add(this.chartWave);
            this.tabScanning.Controls.Add(this.panelButton);
            this.tabScanning.Controls.Add(this.pnlSetting);
            this.tabScanning.Controls.Add(this.statusStrip1);
            this.tabScanning.Location = new System.Drawing.Point(4, 32);
            this.tabScanning.Name = "tabScanning";
            this.tabScanning.Padding = new System.Windows.Forms.Padding(3);
            this.tabScanning.Size = new System.Drawing.Size(1016, 525);
            this.tabScanning.TabIndex = 3;
            this.tabScanning.Text = "Scanning";
            // 
            // chartWave
            // 
            this.chartWave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartWave.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWave.Legends.Add(legend1);
            this.chartWave.Location = new System.Drawing.Point(3, 3);
            this.chartWave.Name = "chartWave";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWave.Series.Add(series1);
            this.chartWave.Size = new System.Drawing.Size(1010, 215);
            this.chartWave.TabIndex = 0;
            this.chartWave.Text = "WaveChart";
            // 
            // panelButton
            // 
            this.panelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButton.Controls.Add(this.btnReset);
            this.panelButton.Controls.Add(this.btnBackground);
            this.panelButton.Controls.Add(this.btnScan);
            this.panelButton.Controls.Add(this.btnProcess);
            this.panelButton.Location = new System.Drawing.Point(3, 414);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1010, 83);
            this.panelButton.TabIndex = 14;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReset.Image = global::PKDSS.MonoApp.Properties.Resources.reset;
            this.btnReset.ImageActive = null;
            this.btnReset.Location = new System.Drawing.Point(18, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 71);
            this.btnReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnReset.TabIndex = 8;
            this.btnReset.TabStop = false;
            this.btnReset.Zoom = 10;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBackground
            // 
            this.btnBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnBackground.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackground.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackground.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBackground.Location = new System.Drawing.Point(123, 3);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(248, 71);
            this.btnBackground.TabIndex = 13;
            this.btnBackground.Text = "Background";
            this.btnBackground.UseVisualStyleBackColor = false;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.btnScan.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnScan.Location = new System.Drawing.Point(414, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(248, 71);
            this.btnScan.TabIndex = 10;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProcess.Location = new System.Drawing.Point(712, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(248, 71);
            this.btnProcess.TabIndex = 11;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.imgOptical);
            this.pnlSetting.Controls.Add(this.imgResolution);
            this.pnlSetting.Controls.Add(this.txtLog);
            this.pnlSetting.Controls.Add(this.panel2);
            this.pnlSetting.Controls.Add(this.lbGuide);
            this.pnlSetting.Controls.Add(this.lbResolution);
            this.pnlSetting.Controls.Add(this.cbObticalGian);
            this.pnlSetting.Controls.Add(this.cbResolution);
            this.pnlSetting.Controls.Add(this.lbOpticalGian);
            this.pnlSetting.Location = new System.Drawing.Point(3, 224);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(1010, 183);
            this.pnlSetting.TabIndex = 7;
            // 
            // imgOptical
            // 
            this.imgOptical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.imgOptical.Image = global::PKDSS.MonoApp.Properties.Resources._checked;
            this.imgOptical.Location = new System.Drawing.Point(227, 137);
            this.imgOptical.Name = "imgOptical";
            this.imgOptical.Size = new System.Drawing.Size(31, 31);
            this.imgOptical.TabIndex = 9;
            this.imgOptical.TabStop = false;
            this.imgOptical.Visible = false;
            // 
            // imgResolution
            // 
            this.imgResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.imgResolution.Image = global::PKDSS.MonoApp.Properties.Resources._checked;
            this.imgResolution.Location = new System.Drawing.Point(227, 75);
            this.imgResolution.Name = "imgResolution";
            this.imgResolution.Size = new System.Drawing.Size(31, 31);
            this.imgResolution.TabIndex = 8;
            this.imgResolution.TabStop = false;
            this.imgResolution.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(679, 47);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(326, 121);
            this.txtLog.TabIndex = 7;
            this.txtLog.Text = "";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(7, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 10);
            this.panel2.TabIndex = 6;
            // 
            // lbGuide
            // 
            this.lbGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGuide.AutoSize = true;
            this.lbGuide.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGuide.Location = new System.Drawing.Point(14, 9);
            this.lbGuide.Name = "lbGuide";
            this.lbGuide.Size = new System.Drawing.Size(216, 23);
            this.lbGuide.TabIndex = 4;
            this.lbGuide.Text = "Please choose your setting";
            // 
            // lbResolution
            // 
            this.lbResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResolution.AutoSize = true;
            this.lbResolution.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResolution.Location = new System.Drawing.Point(5, 49);
            this.lbResolution.Name = "lbResolution";
            this.lbResolution.Size = new System.Drawing.Size(92, 23);
            this.lbResolution.TabIndex = 1;
            this.lbResolution.Text = "Resolution";
            // 
            // cbObticalGian
            // 
            this.cbObticalGian.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbObticalGian.DisplayMember = "0";
            this.cbObticalGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObticalGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbObticalGian.FormattingEnabled = true;
            this.cbObticalGian.Items.AddRange(new object[] {
            "Reflection"});
            this.cbObticalGian.Location = new System.Drawing.Point(9, 135);
            this.cbObticalGian.Name = "cbObticalGian";
            this.cbObticalGian.Size = new System.Drawing.Size(212, 32);
            this.cbObticalGian.TabIndex = 2;
            // 
            // cbResolution
            // 
            this.cbResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResolution.DisplayMember = "0";
            this.cbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Items.AddRange(new object[] {
            "16 nm @ 1550 nm"});
            this.cbResolution.Location = new System.Drawing.Point(9, 75);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(212, 32);
            this.cbResolution.TabIndex = 0;
            // 
            // lbOpticalGian
            // 
            this.lbOpticalGian.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOpticalGian.AutoSize = true;
            this.lbOpticalGian.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOpticalGian.Location = new System.Drawing.Point(5, 110);
            this.lbOpticalGian.Name = "lbOpticalGian";
            this.lbOpticalGian.Size = new System.Drawing.Size(102, 23);
            this.lbOpticalGian.TabIndex = 3;
            this.lbOpticalGian.Text = "Optical Gian";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TxtDeviceStat});
            this.statusStrip1.Location = new System.Drawing.Point(3, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(138, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TxtDeviceStat
            // 
            this.TxtDeviceStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDeviceStat.Name = "TxtDeviceStat";
            this.TxtDeviceStat.Size = new System.Drawing.Size(121, 20);
            this.TxtDeviceStat.Text = "Request Status";
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMenu.Controls.Add(this.tabScanning);
            this.tabMenu.Controls.Add(this.tabDataUnsur);
            this.tabMenu.Controls.Add(this.tabInfoLokasi);
            this.tabMenu.Controls.Add(this.tabRekomendasiPupuk);
            this.tabMenu.Controls.Add(this.tabExportData);
            this.tabMenu.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMenu.Location = new System.Drawing.Point(0, 0);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1024, 561);
            this.tabMenu.TabIndex = 0;
            // 
            // tabDataUnsur
            // 
            this.tabDataUnsur.Controls.Add(this.pnlUser);
            this.tabDataUnsur.Location = new System.Drawing.Point(4, 32);
            this.tabDataUnsur.Name = "tabDataUnsur";
            this.tabDataUnsur.Size = new System.Drawing.Size(1016, 525);
            this.tabDataUnsur.TabIndex = 4;
            this.tabDataUnsur.Text = "Data Unsur";
            this.tabDataUnsur.UseVisualStyleBackColor = true;
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.WBC);
            this.pnlUser.Controls.Add(this.SILT);
            this.pnlUser.Controls.Add(this.SAND);
            this.pnlUser.Controls.Add(this.CLAY);
            this.pnlUser.Controls.Add(this.KB_adjusted);
            this.pnlUser.Controls.Add(this.KTK);
            this.pnlUser.Controls.Add(this.Na);
            this.pnlUser.Controls.Add(this.K);
            this.pnlUser.Controls.Add(this.Mg);
            this.pnlUser.Controls.Add(this.Ca);
            this.pnlUser.Controls.Add(this.Bray1_P2O5);
            this.pnlUser.Controls.Add(this.Olsen_P2O5);
            this.pnlUser.Controls.Add(this.HCl25_K2O);
            this.pnlUser.Controls.Add(this.HCl25_P2O5);
            this.pnlUser.Controls.Add(this.KJELDAHL_N);
            this.pnlUser.Controls.Add(this.PH_KCL);
            this.pnlUser.Controls.Add(this.PH_H2O);
            this.pnlUser.Controls.Add(this.bunifuImageButton2);
            this.pnlUser.Controls.Add(this.btnConfigUser);
            this.pnlUser.Controls.Add(this.bunifuCustomLabel41);
            this.pnlUser.Controls.Add(this.pictureBox4);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUser.Location = new System.Drawing.Point(0, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(1016, 525);
            this.pnlUser.TabIndex = 114;
            // 
            // WBC
            // 
            this.WBC.Controls.Add(this.bunifuCustomLabel59);
            this.WBC.Controls.Add(this.TxtWBC);
            this.WBC.Location = new System.Drawing.Point(13, 169);
            this.WBC.Name = "WBC";
            this.WBC.Size = new System.Drawing.Size(269, 80);
            this.WBC.TabIndex = 117;
            this.WBC.Tag = "WBC";
            // 
            // bunifuCustomLabel59
            // 
            this.bunifuCustomLabel59.AutoSize = true;
            this.bunifuCustomLabel59.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel59.Location = new System.Drawing.Point(4, 5);
            this.bunifuCustomLabel59.Name = "bunifuCustomLabel59";
            this.bunifuCustomLabel59.Size = new System.Drawing.Size(88, 23);
            this.bunifuCustomLabel59.TabIndex = 78;
            this.bunifuCustomLabel59.Tag = "WBC";
            this.bunifuCustomLabel59.Text = "C - org (%)";
            // 
            // TxtWBC
            // 
            this.TxtWBC.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtWBC.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWBC.Location = new System.Drawing.Point(3, 33);
            this.TxtWBC.Name = "TxtWBC";
            this.TxtWBC.ReadOnly = true;
            this.TxtWBC.Size = new System.Drawing.Size(230, 29);
            this.TxtWBC.TabIndex = 78;
            this.TxtWBC.Tag = "WBC";
            this.TxtWBC.Text = "WBC";
            // 
            // SILT
            // 
            this.SILT.Controls.Add(this.bunifuCustomLabel38);
            this.SILT.Controls.Add(this.TxtSILT);
            this.SILT.Location = new System.Drawing.Point(594, 331);
            this.SILT.Name = "SILT";
            this.SILT.Size = new System.Drawing.Size(269, 80);
            this.SILT.TabIndex = 128;
            this.SILT.Tag = "SILT";
            // 
            // bunifuCustomLabel38
            // 
            this.bunifuCustomLabel38.AutoSize = true;
            this.bunifuCustomLabel38.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel38.Location = new System.Drawing.Point(3, 7);
            this.bunifuCustomLabel38.Name = "bunifuCustomLabel38";
            this.bunifuCustomLabel38.Size = new System.Drawing.Size(78, 23);
            this.bunifuCustomLabel38.TabIndex = 99;
            this.bunifuCustomLabel38.Tag = "SILT";
            this.bunifuCustomLabel38.Text = "Debu (%)";
            // 
            // TxtSILT
            // 
            this.TxtSILT.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtSILT.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSILT.Location = new System.Drawing.Point(3, 34);
            this.TxtSILT.Name = "TxtSILT";
            this.TxtSILT.ReadOnly = true;
            this.TxtSILT.Size = new System.Drawing.Size(230, 29);
            this.TxtSILT.TabIndex = 100;
            this.TxtSILT.Tag = "SILT";
            this.TxtSILT.Text = "SILT";
            // 
            // SAND
            // 
            this.SAND.Controls.Add(this.bunifuCustomLabel40);
            this.SAND.Controls.Add(this.TxtSAND);
            this.SAND.Location = new System.Drawing.Point(594, 250);
            this.SAND.Name = "SAND";
            this.SAND.Size = new System.Drawing.Size(269, 80);
            this.SAND.TabIndex = 127;
            this.SAND.Tag = "SAND";
            // 
            // bunifuCustomLabel40
            // 
            this.bunifuCustomLabel40.AutoSize = true;
            this.bunifuCustomLabel40.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel40.Location = new System.Drawing.Point(3, 5);
            this.bunifuCustomLabel40.Name = "bunifuCustomLabel40";
            this.bunifuCustomLabel40.Size = new System.Drawing.Size(76, 23);
            this.bunifuCustomLabel40.TabIndex = 95;
            this.bunifuCustomLabel40.Tag = "SAND";
            this.bunifuCustomLabel40.Text = "Pasir (%)";
            // 
            // TxtSAND
            // 
            this.TxtSAND.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtSAND.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSAND.Location = new System.Drawing.Point(3, 33);
            this.TxtSAND.Name = "TxtSAND";
            this.TxtSAND.ReadOnly = true;
            this.TxtSAND.Size = new System.Drawing.Size(230, 29);
            this.TxtSAND.TabIndex = 96;
            this.TxtSAND.Tag = "SAND";
            this.TxtSAND.Text = "SAND";
            // 
            // CLAY
            // 
            this.CLAY.Controls.Add(this.bunifuCustomLabel39);
            this.CLAY.Controls.Add(this.TxtCLAY);
            this.CLAY.Location = new System.Drawing.Point(594, 169);
            this.CLAY.Name = "CLAY";
            this.CLAY.Size = new System.Drawing.Size(269, 80);
            this.CLAY.TabIndex = 126;
            this.CLAY.Tag = "CLAY";
            // 
            // bunifuCustomLabel39
            // 
            this.bunifuCustomLabel39.AutoSize = true;
            this.bunifuCustomLabel39.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel39.Location = new System.Drawing.Point(2, 5);
            this.bunifuCustomLabel39.Name = "bunifuCustomLabel39";
            this.bunifuCustomLabel39.Size = new System.Drawing.Size(66, 23);
            this.bunifuCustomLabel39.TabIndex = 97;
            this.bunifuCustomLabel39.Tag = "CLAY";
            this.bunifuCustomLabel39.Text = "Liat (%)";
            // 
            // TxtCLAY
            // 
            this.TxtCLAY.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtCLAY.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCLAY.Location = new System.Drawing.Point(3, 33);
            this.TxtCLAY.Name = "TxtCLAY";
            this.TxtCLAY.ReadOnly = true;
            this.TxtCLAY.Size = new System.Drawing.Size(230, 29);
            this.TxtCLAY.TabIndex = 98;
            this.TxtCLAY.Tag = "CLAY";
            this.TxtCLAY.Text = "CLAY";
            // 
            // KB_adjusted
            // 
            this.KB_adjusted.Controls.Add(this.TxtKB_adjusted);
            this.KB_adjusted.Controls.Add(this.bunifuCustomLabel36);
            this.KB_adjusted.Location = new System.Drawing.Point(594, 88);
            this.KB_adjusted.Name = "KB_adjusted";
            this.KB_adjusted.Size = new System.Drawing.Size(269, 80);
            this.KB_adjusted.TabIndex = 125;
            this.KB_adjusted.Tag = "KB_adjusted";
            // 
            // TxtKB_adjusted
            // 
            this.TxtKB_adjusted.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtKB_adjusted.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtKB_adjusted.Location = new System.Drawing.Point(3, 32);
            this.TxtKB_adjusted.Name = "TxtKB_adjusted";
            this.TxtKB_adjusted.ReadOnly = true;
            this.TxtKB_adjusted.Size = new System.Drawing.Size(230, 29);
            this.TxtKB_adjusted.TabIndex = 104;
            this.TxtKB_adjusted.Tag = "KB_adjusted";
            this.TxtKB_adjusted.Text = "KB_adjusted";
            // 
            // bunifuCustomLabel36
            // 
            this.bunifuCustomLabel36.AutoSize = true;
            this.bunifuCustomLabel36.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel36.Location = new System.Drawing.Point(3, 5);
            this.bunifuCustomLabel36.Name = "bunifuCustomLabel36";
            this.bunifuCustomLabel36.Size = new System.Drawing.Size(60, 23);
            this.bunifuCustomLabel36.TabIndex = 103;
            this.bunifuCustomLabel36.Tag = "KB_adjusted";
            this.bunifuCustomLabel36.Text = "KB (%)";
            // 
            // KTK
            // 
            this.KTK.Controls.Add(this.bunifuCustomLabel47);
            this.KTK.Controls.Add(this.TxtKTK);
            this.KTK.Location = new System.Drawing.Point(594, 7);
            this.KTK.Name = "KTK";
            this.KTK.Size = new System.Drawing.Size(269, 80);
            this.KTK.TabIndex = 124;
            this.KTK.Tag = "KTK";
            // 
            // bunifuCustomLabel47
            // 
            this.bunifuCustomLabel47.AutoSize = true;
            this.bunifuCustomLabel47.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel47.Location = new System.Drawing.Point(3, 5);
            this.bunifuCustomLabel47.Name = "bunifuCustomLabel47";
            this.bunifuCustomLabel47.Size = new System.Drawing.Size(125, 23);
            this.bunifuCustomLabel47.TabIndex = 81;
            this.bunifuCustomLabel47.Tag = "KTK";
            this.bunifuCustomLabel47.Text = "KTK (cmolc/kg)";
            // 
            // TxtKTK
            // 
            this.TxtKTK.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtKTK.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtKTK.Location = new System.Drawing.Point(3, 32);
            this.TxtKTK.Name = "TxtKTK";
            this.TxtKTK.ReadOnly = true;
            this.TxtKTK.Size = new System.Drawing.Size(230, 29);
            this.TxtKTK.TabIndex = 82;
            this.TxtKTK.Tag = "KTK";
            this.TxtKTK.Text = "KTK";
            // 
            // Na
            // 
            this.Na.Controls.Add(this.bunifuCustomLabel34);
            this.Na.Controls.Add(this.TxtNa);
            this.Na.Location = new System.Drawing.Point(304, 413);
            this.Na.Name = "Na";
            this.Na.Size = new System.Drawing.Size(269, 80);
            this.Na.TabIndex = 123;
            this.Na.Tag = "Na";
            // 
            // bunifuCustomLabel34
            // 
            this.bunifuCustomLabel34.AutoSize = true;
            this.bunifuCustomLabel34.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel34.Location = new System.Drawing.Point(2, 7);
            this.bunifuCustomLabel34.Name = "bunifuCustomLabel34";
            this.bunifuCustomLabel34.Size = new System.Drawing.Size(113, 23);
            this.bunifuCustomLabel34.TabIndex = 107;
            this.bunifuCustomLabel34.Tag = "Na";
            this.bunifuCustomLabel34.Text = "Na (cmolc/kg)";
            // 
            // TxtNa
            // 
            this.TxtNa.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtNa.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNa.Location = new System.Drawing.Point(3, 31);
            this.TxtNa.Name = "TxtNa";
            this.TxtNa.ReadOnly = true;
            this.TxtNa.Size = new System.Drawing.Size(230, 29);
            this.TxtNa.TabIndex = 108;
            this.TxtNa.Tag = "Na";
            this.TxtNa.Text = "Na";
            // 
            // K
            // 
            this.K.Controls.Add(this.bunifuCustomLabel48);
            this.K.Controls.Add(this.TxtK);
            this.K.Location = new System.Drawing.Point(304, 331);
            this.K.Name = "K";
            this.K.Size = new System.Drawing.Size(269, 80);
            this.K.TabIndex = 122;
            this.K.Tag = "K";
            // 
            // bunifuCustomLabel48
            // 
            this.bunifuCustomLabel48.AutoSize = true;
            this.bunifuCustomLabel48.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel48.Location = new System.Drawing.Point(4, 7);
            this.bunifuCustomLabel48.Name = "bunifuCustomLabel48";
            this.bunifuCustomLabel48.Size = new System.Drawing.Size(104, 23);
            this.bunifuCustomLabel48.TabIndex = 79;
            this.bunifuCustomLabel48.Tag = "K";
            this.bunifuCustomLabel48.Text = "K (cmolc/kg)";
            // 
            // TxtK
            // 
            this.TxtK.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtK.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtK.Location = new System.Drawing.Point(3, 34);
            this.TxtK.Name = "TxtK";
            this.TxtK.ReadOnly = true;
            this.TxtK.Size = new System.Drawing.Size(230, 29);
            this.TxtK.TabIndex = 80;
            this.TxtK.Tag = "K";
            this.TxtK.Text = "K";
            // 
            // Mg
            // 
            this.Mg.Controls.Add(this.bunifuCustomLabel44);
            this.Mg.Controls.Add(this.TxtMg);
            this.Mg.Location = new System.Drawing.Point(304, 250);
            this.Mg.Name = "Mg";
            this.Mg.Size = new System.Drawing.Size(269, 80);
            this.Mg.TabIndex = 121;
            this.Mg.Tag = "Mg";
            // 
            // bunifuCustomLabel44
            // 
            this.bunifuCustomLabel44.AutoSize = true;
            this.bunifuCustomLabel44.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel44.Location = new System.Drawing.Point(3, 5);
            this.bunifuCustomLabel44.Name = "bunifuCustomLabel44";
            this.bunifuCustomLabel44.Size = new System.Drawing.Size(116, 23);
            this.bunifuCustomLabel44.TabIndex = 87;
            this.bunifuCustomLabel44.Tag = "Mg";
            this.bunifuCustomLabel44.Text = "Mg (cmolc/kg)";
            // 
            // TxtMg
            // 
            this.TxtMg.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtMg.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMg.Location = new System.Drawing.Point(3, 33);
            this.TxtMg.Name = "TxtMg";
            this.TxtMg.ReadOnly = true;
            this.TxtMg.Size = new System.Drawing.Size(230, 29);
            this.TxtMg.TabIndex = 88;
            this.TxtMg.Tag = "Mg";
            this.TxtMg.Text = "Mg";
            // 
            // Ca
            // 
            this.Ca.Controls.Add(this.bunifuCustomLabel46);
            this.Ca.Controls.Add(this.TxtCa);
            this.Ca.Location = new System.Drawing.Point(304, 169);
            this.Ca.Name = "Ca";
            this.Ca.Size = new System.Drawing.Size(269, 80);
            this.Ca.TabIndex = 120;
            this.Ca.Tag = "Ca";
            // 
            // bunifuCustomLabel46
            // 
            this.bunifuCustomLabel46.AutoSize = true;
            this.bunifuCustomLabel46.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel46.Location = new System.Drawing.Point(3, 6);
            this.bunifuCustomLabel46.Name = "bunifuCustomLabel46";
            this.bunifuCustomLabel46.Size = new System.Drawing.Size(113, 23);
            this.bunifuCustomLabel46.TabIndex = 83;
            this.bunifuCustomLabel46.Tag = "Ca";
            this.bunifuCustomLabel46.Text = "Ca (cmolc/kg)";
            // 
            // TxtCa
            // 
            this.TxtCa.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtCa.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCa.Location = new System.Drawing.Point(3, 33);
            this.TxtCa.Name = "TxtCa";
            this.TxtCa.ReadOnly = true;
            this.TxtCa.Size = new System.Drawing.Size(230, 29);
            this.TxtCa.TabIndex = 84;
            this.TxtCa.Tag = "Ca";
            this.TxtCa.Text = "Ca";
            // 
            // Bray1_P2O5
            // 
            this.Bray1_P2O5.Controls.Add(this.TxtBray1_P2O5);
            this.Bray1_P2O5.Controls.Add(this.bunifuCustomLabel45);
            this.Bray1_P2O5.Location = new System.Drawing.Point(304, 7);
            this.Bray1_P2O5.Name = "Bray1_P2O5";
            this.Bray1_P2O5.Size = new System.Drawing.Size(269, 80);
            this.Bray1_P2O5.TabIndex = 120;
            this.Bray1_P2O5.Tag = "Bray1_P2O5";
            // 
            // TxtBray1_P2O5
            // 
            this.TxtBray1_P2O5.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtBray1_P2O5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBray1_P2O5.Location = new System.Drawing.Point(3, 32);
            this.TxtBray1_P2O5.Name = "TxtBray1_P2O5";
            this.TxtBray1_P2O5.ReadOnly = true;
            this.TxtBray1_P2O5.Size = new System.Drawing.Size(230, 29);
            this.TxtBray1_P2O5.TabIndex = 86;
            this.TxtBray1_P2O5.Tag = "Bray1_P2O5";
            this.TxtBray1_P2O5.Text = "P2O5 - Bray I";
            // 
            // bunifuCustomLabel45
            // 
            this.bunifuCustomLabel45.AutoSize = true;
            this.bunifuCustomLabel45.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel45.Location = new System.Drawing.Point(3, 6);
            this.bunifuCustomLabel45.Name = "bunifuCustomLabel45";
            this.bunifuCustomLabel45.Size = new System.Drawing.Size(150, 23);
            this.bunifuCustomLabel45.TabIndex = 85;
            this.bunifuCustomLabel45.Tag = "Bray1_P2O5";
            this.bunifuCustomLabel45.Text = "P₂O₅ - Bray I (ppm)";
            // 
            // Olsen_P2O5
            // 
            this.Olsen_P2O5.Controls.Add(this.TxtOlsen_P2O5);
            this.Olsen_P2O5.Controls.Add(this.bunifuCustomLabel43);
            this.Olsen_P2O5.Location = new System.Drawing.Point(304, 88);
            this.Olsen_P2O5.Name = "Olsen_P2O5";
            this.Olsen_P2O5.Size = new System.Drawing.Size(269, 80);
            this.Olsen_P2O5.TabIndex = 119;
            this.Olsen_P2O5.Tag = "Olsen_P2O5";
            // 
            // TxtOlsen_P2O5
            // 
            this.TxtOlsen_P2O5.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtOlsen_P2O5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOlsen_P2O5.Location = new System.Drawing.Point(3, 32);
            this.TxtOlsen_P2O5.Name = "TxtOlsen_P2O5";
            this.TxtOlsen_P2O5.ReadOnly = true;
            this.TxtOlsen_P2O5.Size = new System.Drawing.Size(230, 29);
            this.TxtOlsen_P2O5.TabIndex = 90;
            this.TxtOlsen_P2O5.Tag = "Olsen_P2O5";
            this.TxtOlsen_P2O5.Text = "Olsen_P2O5";
            // 
            // bunifuCustomLabel43
            // 
            this.bunifuCustomLabel43.AutoSize = true;
            this.bunifuCustomLabel43.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel43.Location = new System.Drawing.Point(4, 5);
            this.bunifuCustomLabel43.Name = "bunifuCustomLabel43";
            this.bunifuCustomLabel43.Size = new System.Drawing.Size(151, 23);
            this.bunifuCustomLabel43.TabIndex = 90;
            this.bunifuCustomLabel43.Tag = "Olsen_P2O5";
            this.bunifuCustomLabel43.Text = "P₂O₅ - Olsen (ppm)";
            // 
            // HCl25_K2O
            // 
            this.HCl25_K2O.Controls.Add(this.bunifuCustomLabel52);
            this.HCl25_K2O.Controls.Add(this.TxtHCl25_K2O);
            this.HCl25_K2O.Location = new System.Drawing.Point(13, 413);
            this.HCl25_K2O.Name = "HCl25_K2O";
            this.HCl25_K2O.Size = new System.Drawing.Size(269, 80);
            this.HCl25_K2O.TabIndex = 118;
            this.HCl25_K2O.Tag = "HCl25_K2O";
            // 
            // bunifuCustomLabel52
            // 
            this.bunifuCustomLabel52.AutoSize = true;
            this.bunifuCustomLabel52.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel52.Location = new System.Drawing.Point(3, 6);
            this.bunifuCustomLabel52.Name = "bunifuCustomLabel52";
            this.bunifuCustomLabel52.Size = new System.Drawing.Size(194, 23);
            this.bunifuCustomLabel52.TabIndex = 71;
            this.bunifuCustomLabel52.Tag = "HCl25_K2O";
            this.bunifuCustomLabel52.Text = "K₂O - HCl 25% (mg/100g)";
            // 
            // TxtHCl25_K2O
            // 
            this.TxtHCl25_K2O.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtHCl25_K2O.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHCl25_K2O.Location = new System.Drawing.Point(3, 32);
            this.TxtHCl25_K2O.Name = "TxtHCl25_K2O";
            this.TxtHCl25_K2O.ReadOnly = true;
            this.TxtHCl25_K2O.Size = new System.Drawing.Size(230, 29);
            this.TxtHCl25_K2O.TabIndex = 72;
            this.TxtHCl25_K2O.Tag = "HCl25_K2O";
            this.TxtHCl25_K2O.Text = "HCl25_K2O";
            // 
            // HCl25_P2O5
            // 
            this.HCl25_P2O5.Controls.Add(this.bunifuCustomLabel42);
            this.HCl25_P2O5.Controls.Add(this.TxtHCl25_P2O5);
            this.HCl25_P2O5.Location = new System.Drawing.Point(13, 331);
            this.HCl25_P2O5.Name = "HCl25_P2O5";
            this.HCl25_P2O5.Size = new System.Drawing.Size(269, 80);
            this.HCl25_P2O5.TabIndex = 117;
            this.HCl25_P2O5.Tag = "HCl25_P2O5";
            // 
            // bunifuCustomLabel42
            // 
            this.bunifuCustomLabel42.AutoSize = true;
            this.bunifuCustomLabel42.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel42.Location = new System.Drawing.Point(4, 6);
            this.bunifuCustomLabel42.Name = "bunifuCustomLabel42";
            this.bunifuCustomLabel42.Size = new System.Drawing.Size(200, 23);
            this.bunifuCustomLabel42.TabIndex = 91;
            this.bunifuCustomLabel42.Tag = "HCl25_P2O5";
            this.bunifuCustomLabel42.Text = "P₂O₅ - HCl 25% (mg/100g)";
            // 
            // TxtHCl25_P2O5
            // 
            this.TxtHCl25_P2O5.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtHCl25_P2O5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHCl25_P2O5.Location = new System.Drawing.Point(3, 34);
            this.TxtHCl25_P2O5.Name = "TxtHCl25_P2O5";
            this.TxtHCl25_P2O5.ReadOnly = true;
            this.TxtHCl25_P2O5.Size = new System.Drawing.Size(230, 29);
            this.TxtHCl25_P2O5.TabIndex = 92;
            this.TxtHCl25_P2O5.Tag = "HCl25_P2O5";
            this.TxtHCl25_P2O5.Text = "HCl25_P2O5";
            // 
            // KJELDAHL_N
            // 
            this.KJELDAHL_N.Controls.Add(this.TxtKJELDAHL_N);
            this.KJELDAHL_N.Controls.Add(this.bunifuCustomLabel49);
            this.KJELDAHL_N.Location = new System.Drawing.Point(13, 250);
            this.KJELDAHL_N.Name = "KJELDAHL_N";
            this.KJELDAHL_N.Size = new System.Drawing.Size(269, 80);
            this.KJELDAHL_N.TabIndex = 116;
            this.KJELDAHL_N.Tag = "KJELDAHL_N";
            // 
            // TxtKJELDAHL_N
            // 
            this.TxtKJELDAHL_N.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtKJELDAHL_N.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtKJELDAHL_N.Location = new System.Drawing.Point(3, 33);
            this.TxtKJELDAHL_N.Name = "TxtKJELDAHL_N";
            this.TxtKJELDAHL_N.ReadOnly = true;
            this.TxtKJELDAHL_N.Size = new System.Drawing.Size(230, 29);
            this.TxtKJELDAHL_N.TabIndex = 78;
            this.TxtKJELDAHL_N.Tag = "KJELDAHL_N";
            this.TxtKJELDAHL_N.Text = "KJELDAHL_N";
            // 
            // bunifuCustomLabel49
            // 
            this.bunifuCustomLabel49.AutoSize = true;
            this.bunifuCustomLabel49.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel49.Location = new System.Drawing.Point(4, 5);
            this.bunifuCustomLabel49.Name = "bunifuCustomLabel49";
            this.bunifuCustomLabel49.Size = new System.Drawing.Size(95, 23);
            this.bunifuCustomLabel49.TabIndex = 78;
            this.bunifuCustomLabel49.Tag = "KJELDAHL_N";
            this.bunifuCustomLabel49.Text = "N - total (%)";
            // 
            // PH_KCL
            // 
            this.PH_KCL.Controls.Add(this.bunifuCustomLabel28);
            this.PH_KCL.Controls.Add(this.TxtPH_KCL);
            this.PH_KCL.Location = new System.Drawing.Point(13, 88);
            this.PH_KCL.Name = "PH_KCL";
            this.PH_KCL.Size = new System.Drawing.Size(269, 80);
            this.PH_KCL.TabIndex = 115;
            this.PH_KCL.Tag = "PH_KCL";
            // 
            // bunifuCustomLabel28
            // 
            this.bunifuCustomLabel28.AutoSize = true;
            this.bunifuCustomLabel28.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel28.Location = new System.Drawing.Point(3, 5);
            this.bunifuCustomLabel28.Name = "bunifuCustomLabel28";
            this.bunifuCustomLabel28.Size = new System.Drawing.Size(61, 23);
            this.bunifuCustomLabel28.TabIndex = 110;
            this.bunifuCustomLabel28.Tag = "PH_KCL";
            this.bunifuCustomLabel28.Text = "pH KCl";
            // 
            // TxtPH_KCL
            // 
            this.TxtPH_KCL.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtPH_KCL.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPH_KCL.Location = new System.Drawing.Point(3, 32);
            this.TxtPH_KCL.Name = "TxtPH_KCL";
            this.TxtPH_KCL.ReadOnly = true;
            this.TxtPH_KCL.Size = new System.Drawing.Size(230, 29);
            this.TxtPH_KCL.TabIndex = 110;
            this.TxtPH_KCL.Tag = "PH_KCL";
            this.TxtPH_KCL.Text = "PH_KCL";
            // 
            // PH_H2O
            // 
            this.PH_H2O.Controls.Add(this.bunifuCustomLabel53);
            this.PH_H2O.Controls.Add(this.TxtPH_H2O);
            this.PH_H2O.Location = new System.Drawing.Point(13, 7);
            this.PH_H2O.Name = "PH_H2O";
            this.PH_H2O.Size = new System.Drawing.Size(269, 80);
            this.PH_H2O.TabIndex = 114;
            this.PH_H2O.Tag = "PH_H2O";
            // 
            // bunifuCustomLabel53
            // 
            this.bunifuCustomLabel53.AutoSize = true;
            this.bunifuCustomLabel53.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel53.Location = new System.Drawing.Point(3, 3);
            this.bunifuCustomLabel53.Name = "bunifuCustomLabel53";
            this.bunifuCustomLabel53.Size = new System.Drawing.Size(74, 23);
            this.bunifuCustomLabel53.TabIndex = 69;
            this.bunifuCustomLabel53.Tag = "PH_H2O";
            this.bunifuCustomLabel53.Text = "pH - H₂O";
            // 
            // TxtPH_H2O
            // 
            this.TxtPH_H2O.BorderColor = System.Drawing.Color.SeaGreen;
            this.TxtPH_H2O.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPH_H2O.Location = new System.Drawing.Point(3, 32);
            this.TxtPH_H2O.Name = "TxtPH_H2O";
            this.TxtPH_H2O.ReadOnly = true;
            this.TxtPH_H2O.Size = new System.Drawing.Size(230, 29);
            this.TxtPH_H2O.TabIndex = 70;
            this.TxtPH_H2O.Tag = "PH_H2O";
            this.TxtPH_H2O.Text = "PH_H2O";
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Image = global::PKDSS.MonoApp.Properties.Resources.icons8_automatic_96;
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(2597, 300);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(71, 71);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton2.TabIndex = 113;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // btnConfigUser
            // 
            this.btnConfigUser.BackColor = System.Drawing.Color.Transparent;
            this.btnConfigUser.Image = global::PKDSS.MonoApp.Properties.Resources.icons8_automatic_96;
            this.btnConfigUser.ImageActive = null;
            this.btnConfigUser.Location = new System.Drawing.Point(888, 319);
            this.btnConfigUser.Name = "btnConfigUser";
            this.btnConfigUser.Size = new System.Drawing.Size(71, 71);
            this.btnConfigUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnConfigUser.TabIndex = 113;
            this.btnConfigUser.TabStop = false;
            this.btnConfigUser.Zoom = 10;
            this.btnConfigUser.Click += new System.EventHandler(this.btnConfigUser_Click);
            // 
            // bunifuCustomLabel41
            // 
            this.bunifuCustomLabel41.AutoSize = true;
            this.bunifuCustomLabel41.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel41.Location = new System.Drawing.Point(878, 120);
            this.bunifuCustomLabel41.Name = "bunifuCustomLabel41";
            this.bunifuCustomLabel41.Size = new System.Drawing.Size(94, 23);
            this.bunifuCustomLabel41.TabIndex = 94;
            this.bunifuCustomLabel41.Text = "Data Unsur";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PKDSS.MonoApp.Properties.Resources.shovel;
            this.pictureBox4.Location = new System.Drawing.Point(868, 18);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(104, 88);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 93;
            this.pictureBox4.TabStop = false;
            // 
            // tabInfoLokasi
            // 
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel22);
            this.tabInfoLokasi.Controls.Add(this.txtBalitTanah);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel18);
            this.tabInfoLokasi.Controls.Add(this.txtSample);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel17);
            this.tabInfoLokasi.Controls.Add(this.txtHorizon);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel16);
            this.tabInfoLokasi.Controls.Add(this.cbKabupaten);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel15);
            this.tabInfoLokasi.Controls.Add(this.cbProvinsi);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel14);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel13);
            this.tabInfoLokasi.Controls.Add(this.txtY);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel12);
            this.tabInfoLokasi.Controls.Add(this.lbInisial);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel10);
            this.tabInfoLokasi.Controls.Add(this.txtX);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel11);
            this.tabInfoLokasi.Controls.Add(this.txtKecamatan);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel6);
            this.tabInfoLokasi.Controls.Add(this.txtPengirim);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel7);
            this.tabInfoLokasi.Controls.Add(this.txtDesa);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel8);
            this.tabInfoLokasi.Controls.Add(this.txtNoTanah);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel9);
            this.tabInfoLokasi.Controls.Add(this.txtTahun);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel2);
            this.tabInfoLokasi.Controls.Add(this.txtMappingUnit);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel3);
            this.tabInfoLokasi.Controls.Add(this.txtNoObs);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel4);
            this.tabInfoLokasi.Controls.Add(this.txtNoForm);
            this.tabInfoLokasi.Controls.Add(this.bunifuCustomLabel5);
            this.tabInfoLokasi.Controls.Add(this.pictureBox1);
            this.tabInfoLokasi.Location = new System.Drawing.Point(4, 32);
            this.tabInfoLokasi.Name = "tabInfoLokasi";
            this.tabInfoLokasi.Size = new System.Drawing.Size(1016, 525);
            this.tabInfoLokasi.TabIndex = 5;
            this.tabInfoLokasi.Text = "Info Lokasi Observasi";
            this.tabInfoLokasi.UseVisualStyleBackColor = true;
            // 
            // bunifuCustomLabel22
            // 
            this.bunifuCustomLabel22.AutoSize = true;
            this.bunifuCustomLabel22.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel22.Location = new System.Drawing.Point(724, 316);
            this.bunifuCustomLabel22.Name = "bunifuCustomLabel22";
            this.bunifuCustomLabel22.Size = new System.Drawing.Size(94, 23);
            this.bunifuCustomLabel22.TabIndex = 58;
            this.bunifuCustomLabel22.Text = "Info Lokasi";
            // 
            // txtBalitTanah
            // 
            this.txtBalitTanah.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtBalitTanah.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalitTanah.Location = new System.Drawing.Point(397, 415);
            this.txtBalitTanah.Name = "txtBalitTanah";
            this.txtBalitTanah.Size = new System.Drawing.Size(160, 29);
            this.txtBalitTanah.TabIndex = 56;
            // 
            // bunifuCustomLabel18
            // 
            this.bunifuCustomLabel18.AutoSize = true;
            this.bunifuCustomLabel18.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel18.Location = new System.Drawing.Point(393, 389);
            this.bunifuCustomLabel18.Name = "bunifuCustomLabel18";
            this.bunifuCustomLabel18.Size = new System.Drawing.Size(120, 23);
            this.bunifuCustomLabel18.TabIndex = 55;
            this.bunifuCustomLabel18.Text = "No Balit Tanah";
            // 
            // txtSample
            // 
            this.txtSample.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtSample.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSample.Location = new System.Drawing.Point(205, 415);
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(160, 29);
            this.txtSample.TabIndex = 54;
            // 
            // bunifuCustomLabel17
            // 
            this.bunifuCustomLabel17.AutoSize = true;
            this.bunifuCustomLabel17.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel17.Location = new System.Drawing.Point(201, 389);
            this.bunifuCustomLabel17.Name = "bunifuCustomLabel17";
            this.bunifuCustomLabel17.Size = new System.Drawing.Size(91, 23);
            this.bunifuCustomLabel17.TabIndex = 53;
            this.bunifuCustomLabel17.Text = "No Sample";
            // 
            // txtHorizon
            // 
            this.txtHorizon.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtHorizon.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHorizon.Location = new System.Drawing.Point(12, 415);
            this.txtHorizon.Name = "txtHorizon";
            this.txtHorizon.Size = new System.Drawing.Size(160, 29);
            this.txtHorizon.TabIndex = 52;
            // 
            // bunifuCustomLabel16
            // 
            this.bunifuCustomLabel16.AutoSize = true;
            this.bunifuCustomLabel16.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel16.Location = new System.Drawing.Point(8, 389);
            this.bunifuCustomLabel16.Name = "bunifuCustomLabel16";
            this.bunifuCustomLabel16.Size = new System.Drawing.Size(94, 23);
            this.bunifuCustomLabel16.TabIndex = 51;
            this.bunifuCustomLabel16.Text = "No Horizon";
            // 
            // cbKabupaten
            // 
            this.cbKabupaten.DisplayMember = "0";
            this.cbKabupaten.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKabupaten.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKabupaten.FormattingEnabled = true;
            this.cbKabupaten.Location = new System.Drawing.Point(305, 341);
            this.cbKabupaten.Name = "cbKabupaten";
            this.cbKabupaten.Size = new System.Drawing.Size(255, 31);
            this.cbKabupaten.TabIndex = 50;
            // 
            // bunifuCustomLabel15
            // 
            this.bunifuCustomLabel15.AutoSize = true;
            this.bunifuCustomLabel15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel15.Location = new System.Drawing.Point(301, 315);
            this.bunifuCustomLabel15.Name = "bunifuCustomLabel15";
            this.bunifuCustomLabel15.Size = new System.Drawing.Size(93, 23);
            this.bunifuCustomLabel15.TabIndex = 49;
            this.bunifuCustomLabel15.Text = "Kabupaten";
            // 
            // cbProvinsi
            // 
            this.cbProvinsi.DisplayMember = "0";
            this.cbProvinsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvinsi.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProvinsi.FormattingEnabled = true;
            this.cbProvinsi.Location = new System.Drawing.Point(305, 270);
            this.cbProvinsi.Name = "cbProvinsi";
            this.cbProvinsi.Size = new System.Drawing.Size(255, 31);
            this.cbProvinsi.TabIndex = 48;
            // 
            // bunifuCustomLabel14
            // 
            this.bunifuCustomLabel14.AutoSize = true;
            this.bunifuCustomLabel14.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel14.Location = new System.Drawing.Point(301, 244);
            this.bunifuCustomLabel14.Name = "bunifuCustomLabel14";
            this.bunifuCustomLabel14.Size = new System.Drawing.Size(72, 23);
            this.bunifuCustomLabel14.TabIndex = 47;
            this.bunifuCustomLabel14.Text = "Provinsi";
            // 
            // bunifuCustomLabel13
            // 
            this.bunifuCustomLabel13.AutoSize = true;
            this.bunifuCustomLabel13.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel13.Location = new System.Drawing.Point(140, 273);
            this.bunifuCustomLabel13.Name = "bunifuCustomLabel13";
            this.bunifuCustomLabel13.Size = new System.Drawing.Size(29, 23);
            this.bunifuCustomLabel13.TabIndex = 46;
            this.bunifuCustomLabel13.Text = "Y :";
            // 
            // txtY
            // 
            this.txtY.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtY.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtY.Location = new System.Drawing.Point(179, 270);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(88, 29);
            this.txtY.TabIndex = 45;
            // 
            // bunifuCustomLabel12
            // 
            this.bunifuCustomLabel12.AutoSize = true;
            this.bunifuCustomLabel12.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel12.Location = new System.Drawing.Point(8, 273);
            this.bunifuCustomLabel12.Name = "bunifuCustomLabel12";
            this.bunifuCustomLabel12.Size = new System.Drawing.Size(29, 23);
            this.bunifuCustomLabel12.TabIndex = 44;
            this.bunifuCustomLabel12.Text = "X :";
            // 
            // lbInisial
            // 
            this.lbInisial.BorderColor = System.Drawing.Color.SeaGreen;
            this.lbInisial.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInisial.Location = new System.Drawing.Point(12, 341);
            this.lbInisial.Name = "lbInisial";
            this.lbInisial.Size = new System.Drawing.Size(255, 29);
            this.lbInisial.TabIndex = 43;
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(8, 315);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(54, 23);
            this.bunifuCustomLabel10.TabIndex = 42;
            this.bunifuCustomLabel10.Text = "Inisial";
            // 
            // txtX
            // 
            this.txtX.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtX.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtX.Location = new System.Drawing.Point(47, 270);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(88, 29);
            this.txtX.TabIndex = 41;
            // 
            // bunifuCustomLabel11
            // 
            this.bunifuCustomLabel11.AutoSize = true;
            this.bunifuCustomLabel11.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel11.Location = new System.Drawing.Point(8, 244);
            this.bunifuCustomLabel11.Name = "bunifuCustomLabel11";
            this.bunifuCustomLabel11.Size = new System.Drawing.Size(85, 23);
            this.bunifuCustomLabel11.TabIndex = 40;
            this.bunifuCustomLabel11.Text = "Koordinat";
            // 
            // txtKecamatan
            // 
            this.txtKecamatan.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtKecamatan.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKecamatan.Location = new System.Drawing.Point(305, 212);
            this.txtKecamatan.Name = "txtKecamatan";
            this.txtKecamatan.Size = new System.Drawing.Size(255, 29);
            this.txtKecamatan.TabIndex = 39;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(301, 186);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(95, 23);
            this.bunifuCustomLabel6.TabIndex = 38;
            this.bunifuCustomLabel6.Text = "Kecamatan";
            // 
            // txtPengirim
            // 
            this.txtPengirim.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtPengirim.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPengirim.Location = new System.Drawing.Point(12, 212);
            this.txtPengirim.Name = "txtPengirim";
            this.txtPengirim.Size = new System.Drawing.Size(255, 29);
            this.txtPengirim.TabIndex = 37;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(8, 186);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(77, 23);
            this.bunifuCustomLabel7.TabIndex = 36;
            this.bunifuCustomLabel7.Text = "Pengirim";
            // 
            // txtDesa
            // 
            this.txtDesa.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtDesa.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesa.Location = new System.Drawing.Point(305, 154);
            this.txtDesa.Name = "txtDesa";
            this.txtDesa.Size = new System.Drawing.Size(255, 29);
            this.txtDesa.TabIndex = 35;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(301, 128);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(48, 23);
            this.bunifuCustomLabel8.TabIndex = 34;
            this.bunifuCustomLabel8.Text = "Desa";
            // 
            // txtNoTanah
            // 
            this.txtNoTanah.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtNoTanah.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoTanah.Location = new System.Drawing.Point(12, 154);
            this.txtNoTanah.Name = "txtNoTanah";
            this.txtNoTanah.Size = new System.Drawing.Size(255, 29);
            this.txtNoTanah.TabIndex = 33;
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(8, 128);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(83, 23);
            this.bunifuCustomLabel9.TabIndex = 32;
            this.bunifuCustomLabel9.Text = "No Tanah";
            // 
            // txtTahun
            // 
            this.txtTahun.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtTahun.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTahun.Location = new System.Drawing.Point(305, 96);
            this.txtTahun.Name = "txtTahun";
            this.txtTahun.Size = new System.Drawing.Size(255, 29);
            this.txtTahun.TabIndex = 31;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(301, 70);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(59, 23);
            this.bunifuCustomLabel2.TabIndex = 30;
            this.bunifuCustomLabel2.Text = "Tahun";
            // 
            // txtMappingUnit
            // 
            this.txtMappingUnit.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtMappingUnit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMappingUnit.Location = new System.Drawing.Point(12, 96);
            this.txtMappingUnit.Name = "txtMappingUnit";
            this.txtMappingUnit.Size = new System.Drawing.Size(255, 29);
            this.txtMappingUnit.TabIndex = 29;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(8, 70);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(110, 23);
            this.bunifuCustomLabel3.TabIndex = 28;
            this.bunifuCustomLabel3.Text = "Mapping Unit";
            // 
            // txtNoObs
            // 
            this.txtNoObs.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtNoObs.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoObs.Location = new System.Drawing.Point(305, 38);
            this.txtNoObs.Name = "txtNoObs";
            this.txtNoObs.Size = new System.Drawing.Size(255, 29);
            this.txtNoObs.TabIndex = 27;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(301, 12);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(66, 23);
            this.bunifuCustomLabel4.TabIndex = 26;
            this.bunifuCustomLabel4.Text = "No Obs";
            // 
            // txtNoForm
            // 
            this.txtNoForm.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtNoForm.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoForm.Location = new System.Drawing.Point(12, 38);
            this.txtNoForm.Name = "txtNoForm";
            this.txtNoForm.Size = new System.Drawing.Size(255, 29);
            this.txtNoForm.TabIndex = 25;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(8, 12);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(75, 23);
            this.bunifuCustomLabel5.TabIndex = 24;
            this.bunifuCustomLabel5.Text = "No Form";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PKDSS.MonoApp.Properties.Resources.maps_and_flags_01;
            this.pictureBox1.Location = new System.Drawing.Point(618, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(316, 275);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // tabRekomendasiPupuk
            // 
            this.tabRekomendasiPupuk.Controls.Add(this.BtnSync);
            this.tabRekomendasiPupuk.Controls.Add(this.panel8);
            this.tabRekomendasiPupuk.Controls.Add(this.pnlNpk15);
            this.tabRekomendasiPupuk.Controls.Add(this.pnlUrea15);
            this.tabRekomendasiPupuk.Controls.Add(this.bunifuCustomLabel68);
            this.tabRekomendasiPupuk.Controls.Add(this.bunifuCustomLabel67);
            this.tabRekomendasiPupuk.Controls.Add(this.pictureBox5);
            this.tabRekomendasiPupuk.Controls.Add(this.pictureBox2);
            this.tabRekomendasiPupuk.Controls.Add(this.lbKomoditas);
            this.tabRekomendasiPupuk.Controls.Add(this.cbKomoditas);
            this.tabRekomendasiPupuk.Controls.Add(this.bunifuCustomLabel24);
            this.tabRekomendasiPupuk.Controls.Add(this.pictureBox3);
            this.tabRekomendasiPupuk.Location = new System.Drawing.Point(4, 32);
            this.tabRekomendasiPupuk.Name = "tabRekomendasiPupuk";
            this.tabRekomendasiPupuk.Size = new System.Drawing.Size(1016, 525);
            this.tabRekomendasiPupuk.TabIndex = 6;
            this.tabRekomendasiPupuk.Text = "Rekomendasi Pupuk";
            this.tabRekomendasiPupuk.UseVisualStyleBackColor = true;
            this.tabRekomendasiPupuk.Click += new System.EventHandler(this.tabRekomendasiPupuk_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.bunifuCustomLabel21);
            this.panel8.Controls.Add(this.txtUrea);
            this.panel8.Controls.Add(this.bunifuCustomLabel20);
            this.panel8.Controls.Add(this.txtSP36);
            this.panel8.Controls.Add(this.bunifuCustomLabel19);
            this.panel8.Controls.Add(this.txtKCL);
            this.panel8.Controls.Add(this.bunifuCustomLabel60);
            this.panel8.Controls.Add(this.bunifuCustomLabel62);
            this.panel8.Controls.Add(this.bunifuCustomLabel61);
            this.panel8.Location = new System.Drawing.Point(10, 125);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(405, 207);
            this.panel8.TabIndex = 119;
            // 
            // bunifuCustomLabel21
            // 
            this.bunifuCustomLabel21.AutoSize = true;
            this.bunifuCustomLabel21.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel21.Location = new System.Drawing.Point(10, 11);
            this.bunifuCustomLabel21.Name = "bunifuCustomLabel21";
            this.bunifuCustomLabel21.Size = new System.Drawing.Size(45, 23);
            this.bunifuCustomLabel21.TabIndex = 34;
            this.bunifuCustomLabel21.Text = "Urea";
            // 
            // txtUrea
            // 
            this.txtUrea.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtUrea.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrea.Location = new System.Drawing.Point(14, 37);
            this.txtUrea.Name = "txtUrea";
            this.txtUrea.ReadOnly = true;
            this.txtUrea.Size = new System.Drawing.Size(255, 29);
            this.txtUrea.TabIndex = 35;
            this.txtUrea.TextChanged += new System.EventHandler(this.TxtUrea_TextChanged);
            // 
            // bunifuCustomLabel20
            // 
            this.bunifuCustomLabel20.AutoSize = true;
            this.bunifuCustomLabel20.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel20.Location = new System.Drawing.Point(10, 69);
            this.bunifuCustomLabel20.Name = "bunifuCustomLabel20";
            this.bunifuCustomLabel20.Size = new System.Drawing.Size(53, 23);
            this.bunifuCustomLabel20.TabIndex = 36;
            this.bunifuCustomLabel20.Text = "SP-36";
            // 
            // txtSP36
            // 
            this.txtSP36.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtSP36.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSP36.Location = new System.Drawing.Point(14, 95);
            this.txtSP36.Name = "txtSP36";
            this.txtSP36.ReadOnly = true;
            this.txtSP36.Size = new System.Drawing.Size(255, 29);
            this.txtSP36.TabIndex = 37;
            this.txtSP36.TextChanged += new System.EventHandler(this.TxtSP36_TextChanged);
            // 
            // bunifuCustomLabel19
            // 
            this.bunifuCustomLabel19.AutoSize = true;
            this.bunifuCustomLabel19.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel19.Location = new System.Drawing.Point(10, 127);
            this.bunifuCustomLabel19.Name = "bunifuCustomLabel19";
            this.bunifuCustomLabel19.Size = new System.Drawing.Size(36, 23);
            this.bunifuCustomLabel19.TabIndex = 38;
            this.bunifuCustomLabel19.Text = "KCl";
            // 
            // txtKCL
            // 
            this.txtKCL.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtKCL.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKCL.Location = new System.Drawing.Point(14, 153);
            this.txtKCL.Name = "txtKCL";
            this.txtKCL.ReadOnly = true;
            this.txtKCL.Size = new System.Drawing.Size(255, 29);
            this.txtKCL.TabIndex = 39;
            this.txtKCL.TextChanged += new System.EventHandler(this.TxtKCL_TextChanged);
            // 
            // bunifuCustomLabel60
            // 
            this.bunifuCustomLabel60.AutoSize = true;
            this.bunifuCustomLabel60.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel60.Location = new System.Drawing.Point(275, 40);
            this.bunifuCustomLabel60.Name = "bunifuCustomLabel60";
            this.bunifuCustomLabel60.Size = new System.Drawing.Size(52, 23);
            this.bunifuCustomLabel60.TabIndex = 104;
            this.bunifuCustomLabel60.Text = "kg/ha";
            // 
            // bunifuCustomLabel62
            // 
            this.bunifuCustomLabel62.AutoSize = true;
            this.bunifuCustomLabel62.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel62.Location = new System.Drawing.Point(275, 156);
            this.bunifuCustomLabel62.Name = "bunifuCustomLabel62";
            this.bunifuCustomLabel62.Size = new System.Drawing.Size(52, 23);
            this.bunifuCustomLabel62.TabIndex = 106;
            this.bunifuCustomLabel62.Text = "kg/ha";
            // 
            // bunifuCustomLabel61
            // 
            this.bunifuCustomLabel61.AutoSize = true;
            this.bunifuCustomLabel61.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel61.Location = new System.Drawing.Point(275, 98);
            this.bunifuCustomLabel61.Name = "bunifuCustomLabel61";
            this.bunifuCustomLabel61.Size = new System.Drawing.Size(52, 23);
            this.bunifuCustomLabel61.TabIndex = 105;
            this.bunifuCustomLabel61.Text = "kg/ha";
            // 
            // pnlNpk15
            // 
            this.pnlNpk15.Controls.Add(this.bunifuCustomLabel66);
            this.pnlNpk15.Controls.Add(this.txtNpk15);
            this.pnlNpk15.Controls.Add(this.bunifuCustomLabel64);
            this.pnlNpk15.Location = new System.Drawing.Point(443, 52);
            this.pnlNpk15.Name = "pnlNpk15";
            this.pnlNpk15.Size = new System.Drawing.Size(369, 71);
            this.pnlNpk15.TabIndex = 118;
            // 
            // bunifuCustomLabel66
            // 
            this.bunifuCustomLabel66.AutoSize = true;
            this.bunifuCustomLabel66.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel66.Location = new System.Drawing.Point(3, 9);
            this.bunifuCustomLabel66.Name = "bunifuCustomLabel66";
            this.bunifuCustomLabel66.Size = new System.Drawing.Size(110, 23);
            this.bunifuCustomLabel66.TabIndex = 109;
            this.bunifuCustomLabel66.Text = "NPK 15:15:15";
            // 
            // txtNpk15
            // 
            this.txtNpk15.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtNpk15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNpk15.Location = new System.Drawing.Point(7, 35);
            this.txtNpk15.Name = "txtNpk15";
            this.txtNpk15.ReadOnly = true;
            this.txtNpk15.Size = new System.Drawing.Size(255, 29);
            this.txtNpk15.TabIndex = 110;
            // 
            // bunifuCustomLabel64
            // 
            this.bunifuCustomLabel64.AutoSize = true;
            this.bunifuCustomLabel64.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel64.Location = new System.Drawing.Point(268, 38);
            this.bunifuCustomLabel64.Name = "bunifuCustomLabel64";
            this.bunifuCustomLabel64.Size = new System.Drawing.Size(52, 23);
            this.bunifuCustomLabel64.TabIndex = 113;
            this.bunifuCustomLabel64.Text = "kg/ha";
            // 
            // pnlUrea15
            // 
            this.pnlUrea15.Controls.Add(this.bunifuCustomLabel65);
            this.pnlUrea15.Controls.Add(this.txtUrea15);
            this.pnlUrea15.Controls.Add(this.bunifuCustomLabel63);
            this.pnlUrea15.Location = new System.Drawing.Point(443, 125);
            this.pnlUrea15.Name = "pnlUrea15";
            this.pnlUrea15.Size = new System.Drawing.Size(369, 71);
            this.pnlUrea15.TabIndex = 117;
            // 
            // bunifuCustomLabel65
            // 
            this.bunifuCustomLabel65.AutoSize = true;
            this.bunifuCustomLabel65.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel65.Location = new System.Drawing.Point(3, 6);
            this.bunifuCustomLabel65.Name = "bunifuCustomLabel65";
            this.bunifuCustomLabel65.Size = new System.Drawing.Size(45, 23);
            this.bunifuCustomLabel65.TabIndex = 111;
            this.bunifuCustomLabel65.Text = "Urea";
            // 
            // txtUrea15
            // 
            this.txtUrea15.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtUrea15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrea15.Location = new System.Drawing.Point(7, 32);
            this.txtUrea15.Name = "txtUrea15";
            this.txtUrea15.ReadOnly = true;
            this.txtUrea15.Size = new System.Drawing.Size(255, 29);
            this.txtUrea15.TabIndex = 112;
            // 
            // bunifuCustomLabel63
            // 
            this.bunifuCustomLabel63.AutoSize = true;
            this.bunifuCustomLabel63.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel63.Location = new System.Drawing.Point(268, 35);
            this.bunifuCustomLabel63.Name = "bunifuCustomLabel63";
            this.bunifuCustomLabel63.Size = new System.Drawing.Size(52, 23);
            this.bunifuCustomLabel63.TabIndex = 114;
            this.bunifuCustomLabel63.Text = "kg/ha";
            // 
            // bunifuCustomLabel68
            // 
            this.bunifuCustomLabel68.AutoSize = true;
            this.bunifuCustomLabel68.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel68.Location = new System.Drawing.Point(18, 95);
            this.bunifuCustomLabel68.Name = "bunifuCustomLabel68";
            this.bunifuCustomLabel68.Size = new System.Drawing.Size(226, 27);
            this.bunifuCustomLabel68.TabIndex = 116;
            this.bunifuCustomLabel68.Text = "Rekomendasi Pupuk";
            // 
            // bunifuCustomLabel67
            // 
            this.bunifuCustomLabel67.AutoSize = true;
            this.bunifuCustomLabel67.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel67.Location = new System.Drawing.Point(438, 15);
            this.bunifuCustomLabel67.Name = "bunifuCustomLabel67";
            this.bunifuCustomLabel67.Size = new System.Drawing.Size(374, 27);
            this.bunifuCustomLabel67.TabIndex = 115;
            this.bunifuCustomLabel67.Text = "Rekomendasi Pupuk NPK 15:15:15";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PKDSS.MonoApp.Properties.Resources.corn__2_;
            this.pictureBox5.Location = new System.Drawing.Point(675, 335);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(119, 90);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 108;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PKDSS.MonoApp.Properties.Resources.image_150nw_764148709;
            this.pictureBox2.Location = new System.Drawing.Point(625, 254);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 107;
            this.pictureBox2.TabStop = false;
            // 
            // lbKomoditas
            // 
            this.lbKomoditas.AutoSize = true;
            this.lbKomoditas.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKomoditas.Location = new System.Drawing.Point(18, 15);
            this.lbKomoditas.Name = "lbKomoditas";
            this.lbKomoditas.Size = new System.Drawing.Size(124, 27);
            this.lbKomoditas.TabIndex = 102;
            this.lbKomoditas.Text = "Komoditas";
            // 
            // cbKomoditas
            // 
            this.cbKomoditas.DisplayMember = "0";
            this.cbKomoditas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKomoditas.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKomoditas.FormattingEnabled = true;
            this.cbKomoditas.Location = new System.Drawing.Point(22, 45);
            this.cbKomoditas.Name = "cbKomoditas";
            this.cbKomoditas.Size = new System.Drawing.Size(255, 31);
            this.cbKomoditas.TabIndex = 103;
            this.cbKomoditas.SelectedIndexChanged += new System.EventHandler(this.CbKomoditas_SelectedIndexChanged);
            // 
            // bunifuCustomLabel24
            // 
            this.bunifuCustomLabel24.AutoSize = true;
            this.bunifuCustomLabel24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel24.Location = new System.Drawing.Point(634, 437);
            this.bunifuCustomLabel24.Name = "bunifuCustomLabel24";
            this.bunifuCustomLabel24.Size = new System.Drawing.Size(202, 24);
            this.bunifuCustomLabel24.TabIndex = 60;
            this.bunifuCustomLabel24.Text = "Rekomendasi Pupuk";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PKDSS.MonoApp.Properties.Resources.soy;
            this.pictureBox3.Location = new System.Drawing.Point(736, 254);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(119, 90);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 59;
            this.pictureBox3.TabStop = false;
            // 
            // tabExportData
            // 
            this.tabExportData.Controls.Add(this.panel4);
            this.tabExportData.Location = new System.Drawing.Point(4, 32);
            this.tabExportData.Name = "tabExportData";
            this.tabExportData.Size = new System.Drawing.Size(1016, 525);
            this.tabExportData.TabIndex = 7;
            this.tabExportData.Text = "Export Data";
            this.tabExportData.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1016, 524);
            this.panel4.TabIndex = 101;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearDB);
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Controls.Add(this.dgUnsur);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 466);
            this.panel3.TabIndex = 103;
            // 
            // btnClearDB
            // 
            this.btnClearDB.BackColor = System.Drawing.Color.White;
            this.btnClearDB.Image = global::PKDSS.MonoApp.Properties.Resources.trash;
            this.btnClearDB.ImageActive = null;
            this.btnClearDB.Location = new System.Drawing.Point(875, 3);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(30, 23);
            this.btnClearDB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClearDB.TabIndex = 102;
            this.btnClearDB.TabStop = false;
            this.btnClearDB.Zoom = 10;
            this.btnClearDB.Click += new System.EventHandler(this.BtnClearDB_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExport.Location = new System.Drawing.Point(875, 195);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(133, 101);
            this.btnExport.TabIndex = 100;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // dgUnsur
            // 
            this.dgUnsur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUnsur.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgUnsur.Location = new System.Drawing.Point(0, 0);
            this.dgUnsur.Name = "dgUnsur";
            this.dgUnsur.Size = new System.Drawing.Size(869, 466);
            this.dgUnsur.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dateUntil);
            this.panel5.Controls.Add(this.dateFrom);
            this.panel5.Controls.Add(this.btnFilter);
            this.panel5.Controls.Add(this.btnResetFilter);
            this.panel5.Controls.Add(this.bunifuCustomLabel25);
            this.panel5.Controls.Add(this.bunifuCustomLabel27);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1016, 58);
            this.panel5.TabIndex = 1;
            // 
            // dateUntil
            // 
            this.dateUntil.CustomFormat = "dd/MM/yyyy";
            this.dateUntil.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateUntil.Location = new System.Drawing.Point(558, 13);
            this.dateUntil.Name = "dateUntil";
            this.dateUntil.Size = new System.Drawing.Size(166, 26);
            this.dateUntil.TabIndex = 107;
            this.dateUntil.Value = new System.DateTime(2019, 7, 4, 20, 7, 35, 0);
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yyyy";
            this.dateFrom.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(128, 13);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(178, 26);
            this.dateFrom.TabIndex = 106;
            this.dateFrom.Value = new System.DateTime(2019, 7, 4, 20, 7, 35, 0);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.White;
            this.btnFilter.Image = global::PKDSS.MonoApp.Properties.Resources.icons8_filter_40;
            this.btnFilter.ImageActive = null;
            this.btnFilter.Location = new System.Drawing.Point(886, 9);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(46, 37);
            this.btnFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFilter.TabIndex = 105;
            this.btnFilter.TabStop = false;
            this.btnFilter.Zoom = 10;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.White;
            this.btnResetFilter.Image = global::PKDSS.MonoApp.Properties.Resources.clear_filters;
            this.btnResetFilter.ImageActive = null;
            this.btnResetFilter.Location = new System.Drawing.Point(953, 9);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(46, 37);
            this.btnResetFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnResetFilter.TabIndex = 103;
            this.btnResetFilter.TabStop = false;
            this.btnResetFilter.Zoom = 10;
            this.btnResetFilter.Click += new System.EventHandler(this.BtnResetFilter_Click);
            // 
            // bunifuCustomLabel25
            // 
            this.bunifuCustomLabel25.AutoSize = true;
            this.bunifuCustomLabel25.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel25.Location = new System.Drawing.Point(17, 15);
            this.bunifuCustomLabel25.Name = "bunifuCustomLabel25";
            this.bunifuCustomLabel25.Size = new System.Drawing.Size(88, 23);
            this.bunifuCustomLabel25.TabIndex = 88;
            this.bunifuCustomLabel25.Tag = "";
            this.bunifuCustomLabel25.Text = "Date From";
            // 
            // bunifuCustomLabel27
            // 
            this.bunifuCustomLabel27.AutoSize = true;
            this.bunifuCustomLabel27.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel27.Location = new System.Drawing.Point(453, 15);
            this.bunifuCustomLabel27.Name = "bunifuCustomLabel27";
            this.bunifuCustomLabel27.Size = new System.Drawing.Size(82, 23);
            this.bunifuCustomLabel27.TabIndex = 93;
            this.bunifuCustomLabel27.Tag = "";
            this.bunifuCustomLabel27.Text = "Date Until";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabMenu);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMain.Location = new System.Drawing.Point(0, 39);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1024, 561);
            this.pnlMain.TabIndex = 1;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(3, 9);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(129, 23);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "Soil Sensing v0.1";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Image = global::PKDSS.MonoApp.Properties.Resources.icons8_close_window_96;
            this.btnExit.ImageActive = null;
            this.btnExit.Location = new System.Drawing.Point(972, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 33);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // BtnSync
            // 
            this.BtnSync.Location = new System.Drawing.Point(10, 338);
            this.BtnSync.Name = "BtnSync";
            this.BtnSync.Size = new System.Drawing.Size(196, 41);
            this.BtnSync.TabIndex = 120;
            this.BtnSync.Text = "&Sync Data ke Server";
            this.BtnSync.UseVisualStyleBackColor = true;
            // 
            // EntryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.ControlBox = false;
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EntryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soil Sensing v0.1";
            this.tabScanning.ResumeLayout(false);
            this.tabScanning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWave)).EndInit();
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).EndInit();
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOptical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgResolution)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabMenu.ResumeLayout(false);
            this.tabDataUnsur.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.WBC.ResumeLayout(false);
            this.WBC.PerformLayout();
            this.SILT.ResumeLayout(false);
            this.SILT.PerformLayout();
            this.SAND.ResumeLayout(false);
            this.SAND.PerformLayout();
            this.CLAY.ResumeLayout(false);
            this.CLAY.PerformLayout();
            this.KB_adjusted.ResumeLayout(false);
            this.KB_adjusted.PerformLayout();
            this.KTK.ResumeLayout(false);
            this.KTK.PerformLayout();
            this.Na.ResumeLayout(false);
            this.Na.PerformLayout();
            this.K.ResumeLayout(false);
            this.K.PerformLayout();
            this.Mg.ResumeLayout(false);
            this.Mg.PerformLayout();
            this.Ca.ResumeLayout(false);
            this.Ca.PerformLayout();
            this.Bray1_P2O5.ResumeLayout(false);
            this.Bray1_P2O5.PerformLayout();
            this.Olsen_P2O5.ResumeLayout(false);
            this.Olsen_P2O5.PerformLayout();
            this.HCl25_K2O.ResumeLayout(false);
            this.HCl25_K2O.PerformLayout();
            this.HCl25_P2O5.ResumeLayout(false);
            this.HCl25_P2O5.PerformLayout();
            this.KJELDAHL_N.ResumeLayout(false);
            this.KJELDAHL_N.PerformLayout();
            this.PH_KCL.ResumeLayout(false);
            this.PH_KCL.PerformLayout();
            this.PH_H2O.ResumeLayout(false);
            this.PH_H2O.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfigUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabInfoLokasi.ResumeLayout(false);
            this.tabInfoLokasi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabRekomendasiPupuk.ResumeLayout(false);
            this.tabRekomendasiPupuk.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnlNpk15.ResumeLayout(false);
            this.pnlNpk15.PerformLayout();
            this.pnlUrea15.ResumeLayout(false);
            this.pnlUrea15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabExportData.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClearDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUnsur)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResetFilter)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TimerFile;
        private System.Windows.Forms.TabPage tabScanning;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnScan;
        private Bunifu.Framework.UI.BunifuImageButton btnReset;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel lbGuide;
        private Bunifu.Framework.UI.BunifuCustomLabel lbResolution;
        private System.Windows.Forms.ComboBox cbObticalGian;
        private System.Windows.Forms.ComboBox cbResolution;
        private Bunifu.Framework.UI.BunifuCustomLabel lbOpticalGian;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TxtDeviceStat;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabInfoLokasi;
        private System.Windows.Forms.TabPage tabRekomendasiPupuk;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel13;
        private Bunifu.Framework.BunifuCustomTextbox txtY;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel12;
        private Bunifu.Framework.BunifuCustomTextbox lbInisial;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.Framework.BunifuCustomTextbox txtX;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel11;
        private Bunifu.Framework.BunifuCustomTextbox txtKecamatan;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.BunifuCustomTextbox txtPengirim;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.BunifuCustomTextbox txtDesa;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.BunifuCustomTextbox txtNoTanah;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.BunifuCustomTextbox txtTahun;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.BunifuCustomTextbox txtMappingUnit;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.BunifuCustomTextbox txtNoObs;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.BunifuCustomTextbox txtNoForm;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.BunifuCustomTextbox txtBalitTanah;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel18;
        private Bunifu.Framework.BunifuCustomTextbox txtSample;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel17;
        private Bunifu.Framework.BunifuCustomTextbox txtHorizon;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel16;
        private System.Windows.Forms.ComboBox cbKabupaten;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel15;
        private System.Windows.Forms.ComboBox cbProvinsi;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel14;
        private System.Windows.Forms.Button btnBackground;
        private Bunifu.Framework.BunifuCustomTextbox txtKCL;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel19;
        private Bunifu.Framework.BunifuCustomTextbox txtSP36;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel20;
        private Bunifu.Framework.BunifuCustomTextbox txtUrea;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel21;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel22;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel24;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox imgResolution;
        private System.Windows.Forms.PictureBox imgOptical;
        private System.Windows.Forms.Panel panelButton;
        public System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TabPage tabDataUnsur;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuImageButton btnConfigUser;
        private Bunifu.Framework.BunifuCustomTextbox TxtPH_KCL;
        private Bunifu.Framework.BunifuCustomTextbox TxtNa;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel34;
        private Bunifu.Framework.BunifuCustomTextbox TxtKB_adjusted;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel36;
        private Bunifu.Framework.BunifuCustomTextbox TxtSILT;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel38;
        private Bunifu.Framework.BunifuCustomTextbox TxtCLAY;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel39;
        private Bunifu.Framework.BunifuCustomTextbox TxtSAND;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel40;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel41;
        private Bunifu.Framework.BunifuCustomTextbox TxtHCl25_P2O5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel42;
        private Bunifu.Framework.BunifuCustomTextbox TxtOlsen_P2O5;
        private Bunifu.Framework.BunifuCustomTextbox TxtMg;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel44;
        private Bunifu.Framework.BunifuCustomTextbox TxtBray1_P2O5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel45;
        private Bunifu.Framework.BunifuCustomTextbox TxtCa;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel46;
        private Bunifu.Framework.BunifuCustomTextbox TxtKTK;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel47;
        private Bunifu.Framework.BunifuCustomTextbox TxtK;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel48;
        private Bunifu.Framework.BunifuCustomTextbox TxtKJELDAHL_N;
        private Bunifu.Framework.BunifuCustomTextbox TxtHCl25_K2O;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel52;
        private Bunifu.Framework.BunifuCustomTextbox TxtPH_H2O;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel53;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel pnlMain;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.TabPage tabExportData;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel25;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel27;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgUnsur;
        private System.Windows.Forms.Button btnExport;
        private Bunifu.Framework.UI.BunifuImageButton btnClearDB;
        private System.Windows.Forms.Panel panel5;
        private Bunifu.Framework.UI.BunifuImageButton btnResetFilter;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton btnFilter;
        private System.Windows.Forms.DateTimePicker dateUntil;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private Bunifu.Framework.UI.BunifuCustomLabel lbKomoditas;
        private System.Windows.Forms.ComboBox cbKomoditas;
        private System.Windows.Forms.Panel PH_H2O;
        private System.Windows.Forms.Panel HCl25_P2O5;
        private System.Windows.Forms.Panel KJELDAHL_N;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel49;
        private System.Windows.Forms.Panel PH_KCL;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel28;
        private System.Windows.Forms.Panel HCl25_K2O;
        private System.Windows.Forms.Panel Olsen_P2O5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel43;
        private System.Windows.Forms.Panel Bray1_P2O5;
        private System.Windows.Forms.Panel KTK;
        private System.Windows.Forms.Panel Na;
        private System.Windows.Forms.Panel K;
        private System.Windows.Forms.Panel Mg;
        private System.Windows.Forms.Panel Ca;
        private System.Windows.Forms.Panel KB_adjusted;
        private System.Windows.Forms.Panel SILT;
        private System.Windows.Forms.Panel SAND;
        private System.Windows.Forms.Panel CLAY;
        private System.Windows.Forms.Panel WBC;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel59;
        private Bunifu.Framework.BunifuCustomTextbox TxtWBC;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel62;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel61;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel60;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel67;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel63;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel64;
        private Bunifu.Framework.BunifuCustomTextbox txtUrea15;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel65;
        private Bunifu.Framework.BunifuCustomTextbox txtNpk15;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel66;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel68;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnlNpk15;
        private System.Windows.Forms.Panel pnlUrea15;
        public System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWave;
        private System.Windows.Forms.Button BtnSync;
    }
}