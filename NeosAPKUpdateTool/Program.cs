﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NeosAPKPatchingTool
{
    internal class Program
    {
        static string OpenAPKSelection()
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = "apk";
            dialog.Title = string.Format("Please select your NeosOculus.apk file.");
            dialog.FileName = "NeosOculus.apk";
            Console.WriteLine(dialog.Title);

            string path = "";
            if (dialog.ShowDialog() == DialogResult.OK && Path.GetExtension(dialog.FileName) == ".apk") {
                path = dialog.FileName;
            }
            return path;
        }

        static string OpenFolderSelection()
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = "Please select the Neos_Data folder from your PC installation.";
            dialog.UseDescriptionForTitle = true;
            Console.WriteLine(dialog.Description);

            string path = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path_managed = Path.Combine(dialog.SelectedPath, "Managed");
                if (Directory.Exists(path_managed)) {
                    path = dialog.SelectedPath;
                }
            }
            return path;
        }
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("Welcome! This tool aims to restore functionality to Android releases of NeosVR.\nThe program fixes networking issues that were patched in the PC release of NEOS.\n");
            Console.WriteLine("NOTE: Android releases of Neos are not currently maintained by Solirax.\nThis tool is not officially supported by Solirax and may introduce stability issues.");
            Console.WriteLine("-------------------------------------------------------------------------------------\n");

            var depchecker = new DependencyManager();
            depchecker.CheckInstalled();

            string apkpath = (args.Length > 0) ? args[0] : OpenAPKSelection();
            if (apkpath == "") {
                Console.WriteLine("Invalid APK path.");
                Thread.Sleep(2000);
                Environment.Exit(1);
            }

            string datapath = (args.Length > 1) ? args[1] : OpenFolderSelection();
            if (datapath == "") {
                Console.WriteLine("Invalid Neos_Data path.");
                Thread.Sleep(2000);
                Environment.Exit(1);
            }

            var patcher = new PatchingHandler(apkpath, datapath);
            patcher.PatchAPK();
        }
    }
}
