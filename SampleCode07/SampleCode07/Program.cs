using SampleCode07;
using System.Linq;

public class Program
{
    private static readonly double[] array =
    {
        980.0969548024685,
        448.7701170278722,
        476.8396994574119,
        323.87896643249525,
        137.9586537219506,
        183.8177389107478,
        568.6475922417197,
        540.5221554309112,
        60.486847789444134,
        280.0067951846643,
        327.41532924796326,
        916.0709759441389,
        923.7515600275211,
        817.6131103197356,
        396.07448778419587,
        413.5932681191092,
        846.7432663558135,
        90.293040240928,
        822.429870469622,
        475.30153544624557
    };

    private static readonly Human[] HumanArray = new Human[]
    {
        new Human("wospysox",1.3574143076626086,63.481174559656544),
        new Human("woyyoksr",1.3492955888420144,54.864998804549565),
        new Human("srusqrqt",1.0414684992064687,59.598033630279105),
        new Human("ztqszoqt",1.5713577938149816,54.08263103166131),
        new Human("srvjmlwm",1.549174530164061,39.53546131467955),
        new Human("lwzolzlw",1.7902737067582952,80.79824136280146),
        new Human("ntzpvspy",1.6294235373488077,77.97637048512871),
        new Human("llvqxppu",1.1136388587782688,79.82247849048362),
        new Human("tzkmqopn",1.2188769267474253,85.75996673444065),
        new Human("mkjtzswp",1.5520567499134663,77.05288494682179),
        new Human("xzmzuyyt",1.157921775123269,51.652220899675385),
        new Human("wlmstlqq",1.608245088223212,74.56630834337331),
        new Human("opskzrru",1.8078100124351293,82.3905360734972),
        new Human("zkttymkk",1.2782936273182552,62.25647650717681),
        new Human("vlmjsqoy",1.211078248286496,59.11369150173405),
        new Human("rppuzmmy",1.073441356611867,40.517661535421816),
        new Human("yzvrvjwn",1.560464052748877,90.42998772656028),
        new Human("vozoorms",1.1413067103352128,97.25742985007363),
        new Human("mzvxumzx",1.387340542037803,61.88751745785146),
        new Human("qvumxwqm",1.7814995679070422,72.8375742969624),
    };
    public static void Main(string[] args)
    {
        //身長が1.5ｍ以上の人間だけを抜き出す
        var humanHigherThan150cm = HumanArray.Where(human => human.Height > 1.5);
        foreach(var human in humanHigherThan150cm)
        {
            //Console.WriteLine(human.Name);
        }

        //BMIが15-25の人間だけを抜け出す
        var humanBMI = HumanArray.Where(human =>
          {
              double bmi = human.Weight / (human.Height * human.Height);
              return bmi > 15.9 && bmi < 25.0;
          });
        foreach(var human in humanBMI)
        {
            Console.WriteLine(human.Name);
        }
    }

    private static void GenerateRandomHumanArrayCode()
    {
        string code = "";
        for (int i = 0; i < 20; i++)
        {
            var human = Human.GenerateRndom();
            code += "new Human(";
            code += "\"" + human.Name + "\"," + human.Height + "," + human.Weight;
            code += "),\n";
        }
        Console.WriteLine(code);
    }
        //int[] elements = new int[]
        //    {1,5,43,60,42,30,7,4,9};

        //var enen=elements.Where(x=>x%2==0);

        //foreach(var element in enen)
        //{
        //    Console.WriteLine(element);
        //}

    private static void Handson01()
    {
        RepresentativeValueCalculator calclator =
            new RepresentativeValueCalculator(new Median());




        //↑とは別の場所に書かれている想定
        double rValue = calclator.GetRepresentativeValue(array);
        Console.WriteLine("代表値:" + rValue);


        /*
        //ランダムdouble配列をソースコードとして得る
        double[] array = CreateRandomDoubleArray(20);
        Console.WriteLine(GetArrayCode(array));
        */
    }

    //ランダムなdouble配列を作る
    private static double[] CreateRandomDoubleArray(int length)
    {
        Random random = new Random();
        double[] ret = new double[length];

        //0～1000までの範囲でランダムにdouble配列を作る
        for (int i = 0; i < length; i++)
        {
            ret[i] = random.NextDouble() * 1000.0;
        }
        return ret;
    }

    private static string GetArrayCode(double[] array)
    {
        string ret = "{\n" + array[0].ToString();
        for (int i = 1; i < array.Length; i++)
        {
            ret += ",\n" + array[i].ToString();
        }
        ret += "}";
        return ret;
    }

    public static void Handson03()
    {
        Func<int, int, string> func = DelegateFunctions.Power;

        string result = func.Invoke(15, 4);
        Console.WriteLine(result);
    }

    public static void Handson04()
    {
        //ラムダ
        Func<int, int, string> sum = (a, b) => (a + b).ToString();
        //Func<int, int, int> multiply = (a, b) => a * b;

        string result = sum.Invoke(15, 4);
        Console.WriteLine(result);
    }

    public static void Handson05()
    {
        Func<double[], double> getRepresentativeValue = array =>
        {
            //平均値を出す
            double sum = 0.0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum / array.Length;
        };


        //↑とは別の場所に書かれている想定
        double rValue = getRepresentativeValue.Invoke(array);
        Console.WriteLine("代表値:" + rValue);
    }


    public static void Handson06()
    {
        int nunber = 0;

        Console.WriteLine("1:" + nunber);

        Action action = () => nunber++;

        action.Invoke();

        Console.WriteLine("3:" + nunber);

        action.Invoke();
        action.Invoke();
    }
}