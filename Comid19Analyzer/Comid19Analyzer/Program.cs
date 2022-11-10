using System.Linq;

namespace Comid19Analyzer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Covid19Japan data;
            try
            {
                //現在の感染状況をダウンロード
                System.Net.WebClient client = new System.Net.WebClient();
                string json = client.DownloadString("https://www.stopcovid19.jp/data/covid19japan.json");
                //Console.WriteLine(json);

                //jsonデシリアライズ
                Covid19Japan? dat = Newtonsoft.Json.JsonConvert.DeserializeObject<Covid19Japan>(json);

                if (dat == null) return;
                data = dat;
            }
            catch
            {
                return;
            }

            //デシリアライズできているか確認
            //Console.WriteLine(data.lastUpdate);

            //現在の患者数のトップ５
            var orderByNCurrent= data.area.OrderBy(area => -area.ncurrentpatients).ToArray();
            Console.WriteLine("現在の患者数トップ5");
            for(int i=0;i<5;i++)
            {
                var area = orderByNCurrent[i];
                Console.WriteLine(area.name_jp+":"+area.ncurrentpatients);
            }

            var orderByInfectedRate = data.area.OrderBy(area => -((double)area.ncurrentpatients / area.nexits)).ToArray();
            Console.WriteLine("現在の感染率トップ５");
            for(int i=0;i<5;i++)
            {
                var area=orderByInfectedRate[i];
                var percent = (double)area.ncurrentpatients / area.nexits * 100000.0;
                Console.WriteLine(area.name_jp + ":" + area.ncurrentpatients +","+ percent);
            }

            //現在の重曹率
            var orderByHeavyRate = data.area.OrderBy(area => -((double)area.nheavycurrentpatients / area.ncurrentpatients)).ToArray();
            Console.WriteLine("現在の重症率トップ："+orderByHeavyRate[0].name_jp);
        }
    }
}