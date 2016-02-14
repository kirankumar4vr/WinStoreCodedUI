﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace Pearson.PSCWinAutomation.Framework
{
    public class TaskInfo
    {
        public TaskInfo(XElement taskInfoElements, string subjectName)
        {
            SubjectName = subjectName;
            TaskName = taskInfoElements.Attribute("TaskName").Value;
            AdditionalInfo = taskInfoElements.Element("AdditionalInfo").Value;
            Grade = int.Parse(taskInfoElements.Element("Grade").Value);
            Unit = int.Parse(taskInfoElements.Element("Unit").Value);
            Lesson = int.Parse(taskInfoElements.Element("Lesson").Value);
            TaskNumber = int.Parse(taskInfoElements.Element("TaskNumber").Value);
        }
        public string SubjectName
        {
            get;
            set;
        }

        public string TaskName
        {
            get;
            set;
        }
        public string AdditionalInfo
        {
            get;
            set;
        }

        public int Grade
        {
            get;
            set;
        }

        public int Unit
        {
            get;
            set;
        }
        public int Lesson
        {
            get;
            set;
        }
        public int TaskNumber
        {
            get;
            set;
        }
    }
}
