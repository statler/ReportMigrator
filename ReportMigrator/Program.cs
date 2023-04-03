


using System.Text.RegularExpressions;
using System.Text;
using DevExpress.XtraReports.UI;
using cpReportDefinitions;

class Program
{
    static void Main(string[] args)
    {
        foreach (var reportType in typeof(rptTemplate).Assembly.GetTypes().Where(t => typeof(XtraReport).IsAssignableFrom(t)))
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var report = (XtraReport)Activator.CreateInstance(reportType);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            string sourcePrefix = FindSourceFilePrefix(reportType);
            string targetPrefix = GetTargetFilePrefix(reportType);

#pragma warning disable CS8604 // Possible null reference argument.
            MakeRepx(report, targetPrefix);
#pragma warning restore CS8604 // Possible null reference argument.
            MigrateUserCode(reportType, sourcePrefix, targetPrefix);
            MigrateSerializationCode(reportType, targetPrefix);
        }
    }
    static void MakeRepx(XtraReport report, string targetPrefix)
    {
        MemoryStream ms = new MemoryStream();
        report.SaveLayoutToXml(ms);
        ms.Position = 0;
        string reportLayout = new StreamReader(ms).ReadToEnd();
        File.WriteAllText(targetPrefix + ".repx", reportLayout);
    }
    static void MigrateUserCode(Type reportType, string sourcePrefix, string targetPrefix)
    {
        string userCode = File.ReadAllText(sourcePrefix + ".cs").Replace("namespace ClassLibraryNetFramework", "namespace ClassLibraryNetStandard");

        if (reportType.Name != "BaseReport")
        {
            string copyHeadersFromBaseReportCode = @"
            var baseReport = new BaseReport();
            Bands.Remove(Bands[BandKind.PageHeader]);
            Bands.Add(baseReport.Bands[BandKind.PageHeader]);
            Bands.Remove(Bands[BandKind.PageFooter]);
            Bands.Add(baseReport.Bands[BandKind.PageFooter]);";
            userCode = Regex.Replace(userCode, @"^\s+InitializeComponent\(\);", m => m.Groups[0].Value + copyHeadersFromBaseReportCode, RegexOptions.Multiline);
        }

        userCode = Regex.Replace(userCode, reportType.Name + @"\s*:\s*[^{]+{", reportType.Name + " : DevExpress.XtraReports.UI.XtraReport {");

        File.WriteAllText(targetPrefix + ".cs", userCode);
    }
    static void MigrateSerializationCode(Type reportType, string targetPrefix)
    {
        var fields = new Dictionary<string, Tuple<string, string>>();
        var type = reportType;
        while (type != null && type != typeof(XtraReport))
        {
            var src = FindSourceFilePrefix(type);
            string[] lines = File.ReadAllLines(src + ".Designer.cs");
            foreach (var line in lines)
            {
                var match = Regex.Match(line, @"^\s+(?:public|private|protected) ([A-Za-z0-9\.]+) ([A-Za-z0-9]+);");
                if (match.Success && !fields.ContainsKey(match.Groups[2].Value))
                {
                    fields[match.Groups[2].Value] = Tuple.Create(line, match.Groups[1].Value);
                }
            }
            type = type.BaseType;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("namespace ");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        sb.Append(reportType.Namespace.Replace("ClassLibraryNetFramework", "ClassLibraryNetStandard"));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        sb.Append(" {");
        sb.AppendLine("");

        sb.AppendLine("");

        sb.Append("    public partial class ");
        sb.Append(reportType.Name);
        sb.Append(" : DevExpress.XtraReports.UI.XtraReport {");
        sb.AppendLine("");

        sb.AppendLine("        private void InitializeComponent() {");

        sb.Append("            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, \"");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        sb.Append(reportType.FullName.Replace("ClassLibraryNetFramework", "ClassLibraryNetStandard"));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        sb.Append(".repx\");");
        sb.AppendLine("");

        sb.AppendLine("");

        foreach (var kv in fields)
        {
            sb.Append("            this.");
            sb.Append(kv.Key);
            sb.Append(" = reportInitializer.GetControl<");
            sb.Append(kv.Value.Item2);
            sb.Append(">(\"");
            sb.Append(kv.Key);
            sb.Append("\"); ");
            sb.AppendLine("");
        }

        sb.AppendLine("        }");

        foreach (var kv in fields)
        {
            sb.AppendLine(kv.Value.Item1);
        }
        sb.AppendLine("    }");
        sb.AppendLine("}");

        File.WriteAllText(targetPrefix + ".Designer.cs", sb.ToString());
    }
    static string FindSourceFilePrefix(Type reportType)
    {
        return @"..\..\..\ClassLibraryNetFramework\" + reportType.Name;
    }
    static string GetTargetFilePrefix(Type reportType)
    {
        return @"..\..\..\ClassLibraryNetStandard\" + reportType.Name;
    }
}