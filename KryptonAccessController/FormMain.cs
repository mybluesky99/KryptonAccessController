using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using KryptonAccessController.ResourcesFile;
using KryptonAccessController.Home;
using KryptonAccessController.WidgetThread;
using KryptonAccessController.Help;
using KryptonAccessController.International;
using KryptonAccessController.Tool;
using KryptonAccessController.OperationFile;
using KryptonAccessController.Common;
using KryptonAccessController.RelationController;
using KryptonAccessController.RelationUser;
using KryptonAccessController.RelationDepartment;
using KryptonAccessController.RelationManage;
using KryptonAccessController.RelationRealTimeMoni;
using KryptonAccessController.RelationTimePlan;
namespace KryptonAccessController
{
    public partial class FormMain : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private AccessDataBase.Model.Manager model = null;
        private Font Var_Font = new Font("����", 11);
        WebServer webServer = WebServer.getInstance();
        ControllerInfo controllerInfo = ControllerInfo.getInstance();
        DoorUnitInfo doorUnitInfo = DoorUnitInfo.getInstance();
        UserInfo userInfo = UserInfo.getInstance();
        CompanyInfo companyInfo = CompanyInfo.getInstance();
        DepartmentInfo departmentInfo = DepartmentInfo.getInstance();
        CardInfo cardInfo = CardInfo.getInstance();
        ManagerInfo managerInfo = ManagerInfo.getInstance();

        TimeAccessInfo timeAcessInfo = TimeAccessInfo.getInstance();

        public FormMain(AccessDataBase.Model.Manager model)
        {
            InitializeComponent();
            this.model = model;
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            this.Icon = GetResourcesFile.getSystemIco();
            this.notifyIcon1.Icon = GetResourcesFile.getSystemIco();
            this.notifyIcon1.Text = this.Text;

            this.toolStripStatusLabel2.Text = "";
            this.toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.timer1.Interval = 1000;
            this.timer1.Start();

            initUserInterface();

            //WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, webServer);
            //webServer.BringToFrontAndRefresh();

            toolStripMenuItemController_Click(null, null);


        }
        public void initUserInterface()
        {
            if (System.Globalization.CultureInfo.InstalledUICulture.Name == "zh-CN")
                return;

            this.Text = English.FormMainText;
            this.notifyIcon1.Text = this.Text;

            toolStripMenuItemControllerRelation.Text = English.ControllerRelation;
            labelController.Text = toolStripMenuItemController.Text = English.Controller;
            /*
            labelDoorUnit.Text = toolStripMenuItemDoorUnit.Text = English.DoorUnit;
            toolStripMenuItemExpansionBoard.Text = English.ExpansionBoard;
            toolStripMenuItemReader.Text = English.Reader;
            */
            toolStripMenuItemUserRelation.Text = English.UserRelation;
            toolStripMenuItemCompany.Text = English.Company;
            labelDepartment.Text = toolStripMenuItemDepartment.Text = English.Department;
            toolStripMenuItemTimeGroup.Text = English.TimeGroup;
            labelUser.Text = toolStripMenuItemUser.Text = English.User;
            labelCardInfo.Text = toolStripMenuItemCardInfo.Text = English.CardInfo;
            
            toolStripMenuItemTimeRelation.Text = English.TimeRelation;
            toolStripMenuItemTimeZone.Text = English.TimeZone;
            toolStripMenuItemAccessTime.Text = English.AccessTime;
            toolStripMenuItemHoliday.Text = English.Holiday;

            toolStripMenuItemRecordRelation.Text = English.RecordRelation;

            toolStripMenuItemToolRelation.Text = English.ToolRelation;
            toolStripMenuItemDeviceManage.Text = English.DeviceManage;

            toolStripMenuItemHelpRelation.Text = English.HelpRelation;
            toolStripMenuItemOpenHelpFile.Text = English.OpenHelpFile;
            toolStripMenuItemAboutUs.Text = English.AboutUs;

            this.toolStripStatusLabel1.Text = English.SystemManager;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            ImageOperate.DrawStringToPictureBox(pictureBoxController.Image, toolStripMenuItemControllerRelation.Text, Var_Font);
            ImageOperate.DrawStringToPictureBox(pictureBoxUser.Image, toolStripMenuItemUserRelation.Text, Var_Font);
        }
        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            ((ComponentFactory.Krypton.Toolkit.KryptonLabel)sender).StateNormal.ShortText.Color1 = System.Drawing.Color.White; 
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            ((ComponentFactory.Krypton.Toolkit.KryptonLabel)sender).StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
        }

        private void pictureBoxController_Click(object sender, EventArgs e)
        {
            if (panelContentController.Visible == true)
            {
                panelContentController.Visible = false;
                pictureBoxController.Image = Properties.Resources.���±���;

            }
            else
            {
                panelContentController.Visible = true;
                pictureBoxController.Image = Properties.Resources.���ϱ���;
            }
            ImageOperate.DrawStringToPictureBox(pictureBoxController.Image, toolStripMenuItemControllerRelation.Text, Var_Font);
        }

        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            if (panelContentUser.Visible == true)
            {
                panelContentUser.Visible = false;
                pictureBoxUser.Image = Properties.Resources.���±���;

            }
            else
            {
                panelContentUser.Visible = true;
                pictureBoxUser.Image = Properties.Resources.���ϱ���;
            }

            ImageOperate.DrawStringToPictureBox(pictureBoxUser.Image, toolStripMenuItemUserRelation.Text, Var_Font);
        }

        private void toolStripMenuItemAboutUs_Click(object sender, EventArgs e)
        {
            FormAboutUs aboutus = new FormAboutUs();
            aboutus.ShowDialog();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void toolStripMenuItemDeviceManage_Click(object sender, EventArgs e)
        {
            KryptonFormDeviceManage FormDeviceManage = new KryptonFormDeviceManage();
            FormDeviceManage.Show();
        }

        private void toolStripMenuItemController_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, controllerInfo);
            controllerInfo.refreshDataGridView();
        }
        private void toolStripMenuItemDoorUnit_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, doorUnitInfo);
            doorUnitInfo.refreshDataGridView();
        }

        private void toolStripMenuItemUser_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, userInfo);
            userInfo.refreshDataGridView();
        }

        private void toolStripMenuItemCompany_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, companyInfo);
            companyInfo.refreshDataGridView();
        }

        private void toolStripMenuItemDepartment_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, departmentInfo);
        }

        private void toolStripMenuItemCardInfo_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, cardInfo);
        }

        private void toolStripMenuItemTableManager_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, managerInfo);
        }

        private void toolStripMenuItemChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePassword formChangePassword = new FormChangePassword();
            formChangePassword.ShowDialog();
        }

        private void toolStripMenuItemLock_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin(OpenMode.Unclock);
            formLogin.ShowDialog();
        }

        private void toolStripMenuItemConsole_Click(object sender, EventArgs e)
        {
            FormRealTimeMoni formRealTimeMoni = FormRealTimeMoni.getInstance();
            formRealTimeMoni.ShowDialog();
        }

        private void toolStripMenuItemAccessTime_Click(object sender, EventArgs e)
        {
            WidgetThread.WidgetThread.displayFormOnPanel(this.splitContainer1.Panel2.Controls, timeAcessInfo);
        }

        

    }
}