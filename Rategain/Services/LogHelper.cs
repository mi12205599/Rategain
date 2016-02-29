﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace RateGainData.Console.Services
{
    /// <summary>
    /// 日志处理 助手
    /// Log4net测试-Log4net使用封装类
    /// </summary>
    /// <remarks>
    /// </remarks>
    public static class LogHelper
    {
        private readonly static ILog m_log = log4net.LogManager.GetLogger(typeof(object));

        /// <summary>
        /// 初始化日志系统
        /// 在系统运行开始初始化
        /// Global.asax Application_Start ,App.config 内
        /// </summary>
        public static void Init()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            // 不带参数，是从app.config 中配置log4net，这里从log4net.config 中配置
            log4net.Config.XmlConfigurator.Configure(logCfg);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        public static void Write(string message, LogMessageType messageType)
        {
            DoLog(message, messageType, null, Type.GetType("System.Object") );
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        /// <param name="type"></param>
        public static void Write(string message, LogMessageType messageType, Type type)
        {
            DoLog(message, messageType, null, type);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        /// <param name="ex">异常</param>
        public static void Write(string message, LogMessageType messageType, Exception ex)
        {
            DoLog(message, messageType, ex, Type.GetType("System.Object"));
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        /// <param name="ex">异常</param>
        /// <param name="type"></param>
        public static void Write(string message, LogMessageType messageType, Exception ex,
                                 Type type)
        {
            DoLog(message, messageType, ex, type);
        }

        /// <summary>
        /// 断言
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="message">日志信息</param>
        public static void Assert(bool condition, string message)
        {
            Assert(condition, message, Type.GetType("System.Object"));
        }

        /// <summary>
        /// 断言
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="message">日志信息</param>
        /// <param name="type">日志类型</param>
        public static void Assert(bool condition, string message, Type type)
        {
            if (condition == false)
                Write(message, LogMessageType.Info);
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        /// <param name="ex">异常</param>
        /// <param name="type">日志类型</param>
        private static void DoLog(string message, LogMessageType messageType, Exception ex,
                                  Type type)
        {
            switch (messageType)
            {
                case LogMessageType.Debug:
                    LogHelper.m_log.Debug(message, ex);
                    break;

                case LogMessageType.Info:
                    LogHelper.m_log.Info(message, ex);
                    break;

                case LogMessageType.Warn:
                    LogHelper.m_log.Warn(message, ex);
                    break;

                case LogMessageType.Error:
                    LogHelper.m_log.Error(message, ex);
                    break;

                case LogMessageType.Fatal:
                    LogHelper.m_log.Fatal(message, ex);
                    break;
            }
        }

        /// <summary>
        /// 日志类型
        /// </summary>
        public enum LogMessageType
        {
            /// <summary>
            /// 调试
            /// </summary>
            Debug,

            /// <summary>
            /// 信息
            /// </summary>
            Info,

            /// <summary>
            /// 警告
            /// </summary>
            Warn,

            /// <summary>
            /// 错误
            /// </summary>
            Error,

            /// <summary>
            /// 致命错误
            /// </summary>
            Fatal
        }
    }
}
