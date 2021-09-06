﻿using EmployeeManagement.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class ErrorMessages
    {
        /// <summary>
        /// エラーメッセージを格納するリストを用意するコンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public ErrorMessages(){
            itemNameMessageList = new List<string>();
            itemNameMessageList.Add(IdMessage);
            itemNameMessageList.Add(NameMessage);
            itemNameMessageList.Add(BirthDayMessage);
            itemNameMessageList.Add(BirthDayMessage);
            itemNameMessageList.Add(BaseSalaryMessage);

            instructionMessageList = new List<string>();
            instructionMessageList.Add(NullMessage);
            instructionMessageList.Add(LengthMessage);

            correlationList = new List<string>();
            correlationList.Add(EmpIdDuplication);

        }
        DisplayDinoteErrMessage errorMessage = new DisplayDinoteErrMessage();
        
        public string Message ;
        public List<string> itemNameMessageList { get; set; }
        public List<string> instructionMessageList { get; set; }
        public List<string> correlationList { get; set; } 
        public const string IdMessage = "社員ID";
        public const string NameMessage = "氏名";
        public const string BirthDayMessage = "生年月日";
        public const string BaseSalaryMessage = "基本給料";
        public const string NullMessage =  "は必須です";
        public const string LengthMessage = "は指定桁数で入力してください。";
        public const string EmpIdDuplication = "既に登録済みの社員IDです。";
        public const string MastaCorrelation = "マスタに存在しない";
        public const string MastaCorrelation2 = "を指定しています。";
    }
}
