namespace LoadData
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMasterData = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btLoadHospitales = new System.Windows.Forms.Button();
            this.txtHospitales = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btLoadUSVB = new System.Windows.Forms.Button();
            this.txtUSVBPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLoadZBS = new System.Windows.Forms.Button();
            this.txtZBSPath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatosUME = new System.Windows.Forms.TextBox();
            this.btLoadDatosUME = new System.Windows.Forms.Button();
            this.tpFinalData = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.btUpdateDB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btClearDB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btLoadDB = new System.Windows.Forms.Button();
            this.logPanel = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tpMasterData.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tpFinalData.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMasterData);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tpFinalData);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 183);
            this.tabControl.TabIndex = 0;
            // 
            // tpMasterData
            // 
            this.tpMasterData.BackColor = System.Drawing.SystemColors.Control;
            this.tpMasterData.Controls.Add(this.label3);
            this.tpMasterData.Controls.Add(this.btLoadHospitales);
            this.tpMasterData.Controls.Add(this.txtHospitales);
            this.tpMasterData.Controls.Add(this.label2);
            this.tpMasterData.Controls.Add(this.btLoadUSVB);
            this.tpMasterData.Controls.Add(this.txtUSVBPath);
            this.tpMasterData.Controls.Add(this.label1);
            this.tpMasterData.Controls.Add(this.btLoadZBS);
            this.tpMasterData.Controls.Add(this.txtZBSPath);
            this.tpMasterData.Location = new System.Drawing.Point(4, 22);
            this.tpMasterData.Name = "tpMasterData";
            this.tpMasterData.Padding = new System.Windows.Forms.Padding(3);
            this.tpMasterData.Size = new System.Drawing.Size(768, 157);
            this.tpMasterData.TabIndex = 0;
            this.tpMasterData.Text = "Datos Maestros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hospitales";
            // 
            // btLoadHospitales
            // 
            this.btLoadHospitales.BackColor = System.Drawing.SystemColors.Control;
            this.btLoadHospitales.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLoadHospitales.BackgroundImage")));
            this.btLoadHospitales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btLoadHospitales.Location = new System.Drawing.Point(727, 109);
            this.btLoadHospitales.Name = "btLoadHospitales";
            this.btLoadHospitales.Size = new System.Drawing.Size(35, 38);
            this.btLoadHospitales.TabIndex = 7;
            this.toolTip.SetToolTip(this.btLoadHospitales, "Cargar Hospital");
            this.btLoadHospitales.UseVisualStyleBackColor = false;
            this.btLoadHospitales.Click += new System.EventHandler(this.btLoadHospitales_Click);
            // 
            // txtHospitales
            // 
            this.txtHospitales.Location = new System.Drawing.Point(98, 119);
            this.txtHospitales.Name = "txtHospitales";
            this.txtHospitales.Size = new System.Drawing.Size(623, 20);
            this.txtHospitales.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "USVB";
            // 
            // btLoadUSVB
            // 
            this.btLoadUSVB.BackColor = System.Drawing.SystemColors.Control;
            this.btLoadUSVB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLoadUSVB.BackgroundImage")));
            this.btLoadUSVB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btLoadUSVB.Location = new System.Drawing.Point(727, 68);
            this.btLoadUSVB.Name = "btLoadUSVB";
            this.btLoadUSVB.Size = new System.Drawing.Size(35, 38);
            this.btLoadUSVB.TabIndex = 4;
            this.toolTip.SetToolTip(this.btLoadUSVB, "Cargar Unidad de Sporte Vital Básico");
            this.btLoadUSVB.UseVisualStyleBackColor = false;
            this.btLoadUSVB.Click += new System.EventHandler(this.btLoadUSVB_Click);
            // 
            // txtUSVBPath
            // 
            this.txtUSVBPath.Location = new System.Drawing.Point(98, 78);
            this.txtUSVBPath.Name = "txtUSVBPath";
            this.txtUSVBPath.Size = new System.Drawing.Size(623, 20);
            this.txtUSVBPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ZBS";
            // 
            // btLoadZBS
            // 
            this.btLoadZBS.BackColor = System.Drawing.SystemColors.Control;
            this.btLoadZBS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLoadZBS.BackgroundImage")));
            this.btLoadZBS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btLoadZBS.Location = new System.Drawing.Point(727, 22);
            this.btLoadZBS.Name = "btLoadZBS";
            this.btLoadZBS.Size = new System.Drawing.Size(35, 38);
            this.btLoadZBS.TabIndex = 1;
            this.toolTip.SetToolTip(this.btLoadZBS, "Cargar Zona Basica de Salud");
            this.btLoadZBS.UseVisualStyleBackColor = false;
            this.btLoadZBS.Click += new System.EventHandler(this.btLoadZBS_Click);
            // 
            // txtZBSPath
            // 
            this.txtZBSPath.Location = new System.Drawing.Point(98, 32);
            this.txtZBSPath.Name = "txtZBSPath";
            this.txtZBSPath.Size = new System.Drawing.Size(623, 20);
            this.txtZBSPath.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtDatosUME);
            this.tabPage2.Controls.Add(this.btLoadDatosUME);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 157);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos Estudio Temporales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Datos UME";
            // 
            // txtDatosUME
            // 
            this.txtDatosUME.Location = new System.Drawing.Point(86, 66);
            this.txtDatosUME.Name = "txtDatosUME";
            this.txtDatosUME.Size = new System.Drawing.Size(623, 20);
            this.txtDatosUME.TabIndex = 3;
            // 
            // btLoadDatosUME
            // 
            this.btLoadDatosUME.BackColor = System.Drawing.SystemColors.Control;
            this.btLoadDatosUME.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLoadDatosUME.BackgroundImage")));
            this.btLoadDatosUME.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btLoadDatosUME.Location = new System.Drawing.Point(715, 56);
            this.btLoadDatosUME.Name = "btLoadDatosUME";
            this.btLoadDatosUME.Size = new System.Drawing.Size(35, 38);
            this.btLoadDatosUME.TabIndex = 4;
            this.toolTip.SetToolTip(this.btLoadDatosUME, "Cargar Datos Temporales");
            this.btLoadDatosUME.UseVisualStyleBackColor = false;
            this.btLoadDatosUME.Click += new System.EventHandler(this.btLoadDatosUME_Click);
            // 
            // tpFinalData
            // 
            this.tpFinalData.BackColor = System.Drawing.SystemColors.Control;
            this.tpFinalData.Controls.Add(this.label7);
            this.tpFinalData.Controls.Add(this.btUpdateDB);
            this.tpFinalData.Controls.Add(this.label6);
            this.tpFinalData.Controls.Add(this.btClearDB);
            this.tpFinalData.Controls.Add(this.label5);
            this.tpFinalData.Controls.Add(this.btLoadDB);
            this.tpFinalData.Location = new System.Drawing.Point(4, 22);
            this.tpFinalData.Name = "tpFinalData";
            this.tpFinalData.Padding = new System.Windows.Forms.Padding(3);
            this.tpFinalData.Size = new System.Drawing.Size(768, 157);
            this.tpFinalData.TabIndex = 2;
            this.tpFinalData.Text = "Datos Estudio Finales";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(557, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Actualizar datos finales";
            // 
            // btUpdateDB
            // 
            this.btUpdateDB.Image = global::LoadData.Properties.Resources.updateDB64;
            this.btUpdateDB.Location = new System.Drawing.Point(560, 36);
            this.btUpdateDB.Name = "btUpdateDB";
            this.btUpdateDB.Size = new System.Drawing.Size(98, 78);
            this.btUpdateDB.TabIndex = 4;
            this.toolTip.SetToolTip(this.btUpdateDB, "Update DataBase");
            this.btUpdateDB.UseVisualStyleBackColor = true;
            this.btUpdateDB.Click += new System.EventHandler(this.btUpdateDB_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Borrar datos finales";
            // 
            // btClearDB
            // 
            this.btClearDB.Image = global::LoadData.Properties.Resources.removeDB64;
            this.btClearDB.Location = new System.Drawing.Point(332, 36);
            this.btClearDB.Name = "btClearDB";
            this.btClearDB.Size = new System.Drawing.Size(98, 78);
            this.btClearDB.TabIndex = 2;
            this.toolTip.SetToolTip(this.btClearDB, "Clear DataBase");
            this.btClearDB.UseVisualStyleBackColor = true;
            this.btClearDB.Click += new System.EventHandler(this.btClearDB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cargar datos finales";
            // 
            // btLoadDB
            // 
            this.btLoadDB.Image = global::LoadData.Properties.Resources.loadDB64;
            this.btLoadDB.Location = new System.Drawing.Point(94, 36);
            this.btLoadDB.Name = "btLoadDB";
            this.btLoadDB.Size = new System.Drawing.Size(98, 78);
            this.btLoadDB.TabIndex = 0;
            this.toolTip.SetToolTip(this.btLoadDB, "Load DataBase");
            this.btLoadDB.UseVisualStyleBackColor = true;
            this.btLoadDB.Click += new System.EventHandler(this.btLoadDB_Click);
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.txtLog);
            this.logPanel.Location = new System.Drawing.Point(16, 201);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(768, 516);
            this.logPanel.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(762, 510);
            this.txtLog.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 729);
            this.Controls.Add(this.logPanel);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Data";
            this.Load += new System.EventHandler(this.Home_Load);
            this.tabControl.ResumeLayout(false);
            this.tpMasterData.ResumeLayout(false);
            this.tpMasterData.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tpFinalData.ResumeLayout(false);
            this.tpFinalData.PerformLayout();
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMasterData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLoadZBS;
        private System.Windows.Forms.TextBox txtZBSPath;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btLoadUSVB;
        private System.Windows.Forms.TextBox txtUSVBPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btLoadHospitales;
        private System.Windows.Forms.TextBox txtHospitales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btLoadDatosUME;
        private System.Windows.Forms.TextBox txtDatosUME;
        private System.Windows.Forms.TabPage tpFinalData;
        private System.Windows.Forms.Button btLoadDB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btClearDB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btUpdateDB;
    }
}

