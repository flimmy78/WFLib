﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;

namespace WFNetLib
{
    public class ProcessHelper
    {
        public static bool IsRunningProcess(string processName)
        {
            Process[] arrPro = GetProcess();
            foreach (Process p in arrPro)
            {
                if (p.ProcessName == processName) return true;
            }
            return false;
        }

        public static void CloseProcess(string processName)
        {
            Process[] processList=Process.GetProcessesByName(processName);
            if (processList == null)
                return;
            Process process = processList[0]; 
            process.CloseMainWindow();
            //if (!result) process.Kill();
            if (Process.GetProcessesByName(processName).Length != 0)
                process.Kill();
            //return result;
        }

        public static void StartProcess(string fileName)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(fileName);
            process.Start();

        }

        public static Process[] GetProcess(string ip = "")
        {
            if (string.IsNullOrEmpty(ip))
                return Process.GetProcesses();
            return Process.GetProcesses(ip);
        }

    }
}
