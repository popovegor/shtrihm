using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;
using ShtrihM.SCA.Packaging.DataTerminal.Exceptions;
using System.Windows.Forms;

namespace ShtrihM.SCA.Packaging.DataTerminal.Helpers
{
  internal static class ConfigHelper
  {
    public static string GetConnectionString(string key)
    {
      var configPath = GetConfigPath();
      var cs = string.Empty;
      if (File.Exists(configPath) == false)
      {
        var msg = string.Format("Не удалось прочитать файл конфигурации {0}.", configPath);
        throw new ExternalException(msg);
      }
      else
      {
        var xdoc = XDocument.Load(configPath);
        try
        {
          var apps = xdoc.Element("configuration").Element("appSettings").Elements("add");
          cs = apps.SingleOrDefault(e => e.Attribute("key").Value == key).Attribute("value").Value;
        }
        catch (Exception e)
        {
          throw new ExternalException("Не удалось получить настройки подключения.", e);
        }
      }
      return cs;
    }

    private static string GetCurrentDir()
    {
      //MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
      var dir = System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
      //MessageBox.Show(dir);
      return dir;
    }

    public static string GetConfigPath()
    {
      var path = string.Empty;
      var config = GetConfigName();
      if (string.IsNullOrEmpty(config) == false)
      {
        path = string.Concat(GetCurrentDir(), @"\", config);
      }
      return path;
    }

    private static string GetConfigName()
    {
      return "app.config";
    }

    private static string GetConfigNameByAssemblyName()
    {
      var config = string.Empty;
      var assembly = System.Reflection.Assembly.GetExecutingAssembly();
      if (assembly != null)
      {
        var name = assembly.GetName();
        if (name != null)
        {
          config = string.Concat(name.Name, ".exe", ".config");
        }
      }
      return config;
    }

    internal static void SaveConnectionString(string key, string cs)
    {
      var configPath = GetConfigPath();
      if (File.Exists(configPath) == false)
      {
        var msg = string.Format("Не удалось прочитать файл конфигурации {0}.", configPath);
        throw new ExternalException(msg);
      }
      else
      {
        var xdoc = XDocument.Load(configPath);
        try
        {
          var apps = xdoc.Element("configuration").Element("appSettings").Elements("add");
          apps.SingleOrDefault(e => e.Attribute("key").Value == key).Attribute("value").SetValue(cs);
          xdoc.Save(configPath);
        }
        catch (Exception e)
        {
          throw new ExternalException("Не удалось перезаписать настройки подключения к БД.", e);
        }
      }
    }
  }
}
