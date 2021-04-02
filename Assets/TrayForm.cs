using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;

public class TrayForm : Form
{
    private NotifyIcon notifyIcon1;
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.ContextMenu contextMenu1;
    private System.Windows.Forms.MenuItem menuItem1;


    private static AppWindowController appController;

    bool inited = false;

    public TrayForm ()
    {
        if (!inited)
            Init();
    }

    private void Init()
    {
        inited = true;

        appController = new AppWindowController();

        this.components = new System.ComponentModel.Container();
        string path = UnityEngine.Application.streamingAssetsPath + "/WindowsPlayer.ico";
        notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);

        // The Icon property sets the icon that will appear
        // in the systray for this application.
        notifyIcon1.Icon = new Icon(path);

        // The ContextMenu property sets the menu that will
        // appear when the systray icon is right clicked.
        contextMenu1 = new System.Windows.Forms.ContextMenu();
        menuItem1 = new System.Windows.Forms.MenuItem();

        // Initialize contextMenu1
        contextMenu1.MenuItems.AddRange(
                    new System.Windows.Forms.MenuItem[] { menuItem1 });

        // Initialize menuItem1
        menuItem1.Index = 0;
        menuItem1.Text = "E&xit";
        menuItem1.Click += new System.EventHandler(menuItem1_Clickk);

        notifyIcon1.ContextMenu = contextMenu1;

        // The Text property sets the text that will be displayed,
        // in a tooltip, when the mouse hovers over the systray icon.
        notifyIcon1.Text = "Form1 (NotifyIcon example)";
        notifyIcon1.Visible = true;

        // Handle the DoubleClick event to activate the form.
        notifyIcon1.DoubleClick += new System.EventHandler(notifyIcon1_DoubleClick);
        notifyIcon1.Click += new System.EventHandler(notifyIcon1_Click);

    }

    public void MinimizeWindow()
    {
        appController.ShowAsync(AppWindowController.CmdShow.Minimize);
        appController.SetShowInTaskBarPro(false);
    }

    static void menuItem1_Clickk(object Sender, EventArgs e)
    {
        UnityEngine.Application.Quit();
    }

    static void notifyIcon1_Click(object Sender, EventArgs e)
    {
        Debug.Log("On notify icon click");
        appController.ShowAsync(AppWindowController.CmdShow.Restore);
        appController.SetShowInTaskBarPro(true);
    }

    static void notifyIcon1_DoubleClick(object Sender, EventArgs e)
    {
        Debug.Log("On notify icon double click");
        //appController.Maximize();
    }

    public void OnApplicationFocusChange(bool focus)
    {
        if(!focus && appController.IsMinimized())
        {
            appController.SetShowInTaskBarPro(false);
        }
        else
        {
            appController.SetShowInTaskBarPro(true);
        }
    }
}
