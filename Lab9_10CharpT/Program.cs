using System;
using System.Collections;
using System.Collections.Generic;


namespace Pr{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("\nLab 3");
      
      Console.WriteLine("Choose task: ");
      int s = Convert.ToInt32(Console.ReadLine());

  switch(s){
    case 1: { task1();  break;}
    case 2: { task2();  break;}
  }
      
    }



static void task1(){
    Console.WriteLine("\nTask1");
    Console.Write("Numner of triangle: ");
    int n = Convert.ToInt32(Console.ReadLine());
    string c ="Blue";

    for(int f = 0;f<n;f++)
    {Console.Write("\n\n  Triangle "+(f+1));
      int [] a=new int[2];

    Console.Write("\nSides: ");
    try{
    for(int i = 0;i<a.Length;i++)
    {
      a[i]= Convert.ToInt32(Console.ReadLine());
    }}
    catch(OutOfMemoryException e){Console.WriteLine(e.Message);}
    Console.Write("Color: ");
     c=Convert.ToString(Console.ReadLine());

    ITriangle first = new ITriangle ();
    first.col(c);
    int p =first.perimeter(a[0],a[1]);
    Console.Write("\nPerimeter: "+p);
    double s =first.area(a[0],a[1],p);
    Console.Write("\nS: "+s);
    bool t =first.correct(a[0],a[1]);
    Console.Write("\nCorrect: "+t);


    Console.Write("\nChange sides: ");
    int [] k=new int[2];
    try{
    for(int i = 0;i<k.Length;i++)
    {
      k[i]= Convert.ToInt32(Console.ReadLine());
    }}
    catch(IndexOutOfRangeException e){
        Console.WriteLine(e.Message);
    }
    int [] b={k[0],k[1]};
    first.Sidegr=b;
    b=first.Sidegr;


    if (a.Length == k.Length)
        {
            Console.Write("\nA & K Length Match");
        }
        else
        {
            throw new ArrayTypeMismatchException();
        }

    if(a[0]!=0){
        Console.Write("\nK[0]/A[0]: "+k[0]/a[0]);
    }
    else
        {
            throw new DivideByZeroException();
        }

    try{
        object  obj=4;
        int num = (int)obj;
    }
     catch(InvalidCastException e)
        {
            Console.WriteLine(e.Message);
        }
    
    try {
      printnumb(0);
    } catch (StackOverflowException e) {
      Console.WriteLine(e.Message);
    }

    Console.Write("\nSides: ");
    for(int i = 0;i<b.Length;i++)
    {
      Console.Write(+b[i]+" ");
    }
    Console.Write("\nColor: "+ first.Colorgr);
    
    Console.Write("\nIndex: ");
    int ind = Convert.ToInt32(Console.ReadLine());   
    string ch=first[ind];
    if(ch=="0") Console.Write("\nError ");
    Console.Write("So: "+ ch);

    Console.Write("\n++: "+ (first++).show());
    Console.Write("\n--: "+ (first--).show());

    Console.Write("\nBool: "+ (bool)first);
    Console.Write("\n*: "+ (first*2).show());
    
    string str= (string)first;
    Console.Write("\nStr: "+ str);
    ITriangle second = (ITriangle)str;
    Console.Write("\nITriangle: "+ second.show());
    
    } 
}
static void printnumb(int value) {
    Console.WriteLine("Value: " + value);
    printnumb(++value);
  }

class ITriangle: Exception{
  protected int a, b;
  protected string c;

  public int [] sides(int sa, int sb){
    int [] a = {sa,sb};
    return a;   
  }
  public int perimeter(int sa, int sb){
    int p=sa+2*sb;
    return p;   
  }
  public double area (int sa, int sb, int p1){
    int p=p1/2;
    double s=0;
    try{
    s= Math.Sqrt(p*(p1-sa)*(p1-sb)*(p1-sb));}
    catch(Exception e){
        Console.WriteLine(e.Message);
    }
    return s;   
  }
  public bool correct (int sa, int sb){
    if(sa==sb) return true; 
    else return false;
  }

  public void col(string color){
    this.c=color;
  }
  public string show(){
    return "A: "+a+" \n    B: "+b+"  \n    C: "+c;
  }
  public int[] Sidegr{
    get{
      int [] k= {this.a,this.b};
      return k;
    }

    set{
      a=value[0];
      b=value[1];
    }
  }
  public string Colorgr{
    get{
      string s=this.c;
      return s;
    }
  }

  public string this[int ind]{
    get{
      if(ind==0) return $"{a}";
      else if(ind==1) return $"{b}";
      else if(ind==2) return c;
      else return "0";
    }
    
  }

  public static ITriangle operator++ (ITriangle t) {
         t.a += 1;
         t.b += 1;
         return t;
      }

  public static ITriangle operator-- (ITriangle t) {
         t.a -= 1;
         t.b -= 1;
         return t;
  }

  public static explicit operator bool(ITriangle t) {
    return (t.a != 0)&&(t.b != 0);
  }
 
  
  public static ITriangle operator* (ITriangle t,int scal) {
    ITriangle k = new ITriangle();
    k.a = t.a*scal;
    k.b = t.b*scal;
    return k;
  }

  public static explicit operator string(ITriangle t) {
    return $"{t.a}, {t.b}, {t.c}";
  }

  public static explicit operator ITriangle(string str) {
    
    ITriangle t = new ITriangle();
    string[] s = str.Split(',');
    try{
    t.a = int.Parse(s[0].Trim('(', ')'));
    t.b = int.Parse(s[1]);
    t.c = s[2];}
    catch(OverflowException e){
        Console.WriteLine(e.Message);
    }
    return t;
  }


}




static void task2(){
  Conveyor con = new Conveyor("Conv", 50,15,"Process",0);

  Working w = new Working();
  
  con.probability_fail();  

  w.On(con);
  w.Off(con);  
}

public delegate void ConveyorEventHandler(object sender, ConveyorEventArgs e);
public class ConveyorEventArgs : EventArgs{
public string Conveyer_name { get; }
public int Conveyer_numb { get; }
public int Conveyer_day { get;}
public string Conveyer_result { get;}
public double Conveyer_failure { get;}
public ConveyorEventArgs(string name, int numb, int day, double failure, string result){
 Conveyer_name = name; Conveyer_numb = numb; Conveyer_day = day; Conveyer_failure = failure; Conveyer_result = result;
 }

 }


public class Conveyor{
  private string name;
  private int numb;
  private int days;

  public event ConveyorEventHandler Work_fail;
  private string result; 

  private double failure;

  public Conveyor(string name, int numb, int days, string result,double failure=0){
    this.name = name;
    this.numb = numb;
    this.days = days;
    this.result = result;
    this.failure = failure;

  }


protected virtual void OnWork(ConveyorEventArgs e)
 {
  Work_fail?.Invoke(this, e);
 }


public void probability_fail(){
  for (int i = 0; i < days; i++) {
    Random r = new Random();
    int n = r.Next(0, numb);
                
    failure=n/numb;

    // Ймовірність несправностіі висока/мала
    if (failure >= 0.25){
      OnWork(new ConveyorEventArgs(name, numb, days, failure,"Normal"));
    }
    else {
      OnWork(new ConveyorEventArgs(name, numb, days, failure, "So big!"));  }
  }}
}

public class Working{
public void On(Conveyor works){
 works.Work_fail += WorkerEventHandl;
 }
 public void Off(Conveyor works){
 works.Work_fail -= WorkerEventHandl;
 }

public  void WorkerEventHandl(object sender, ConveyorEventArgs e){
  Console.WriteLine($"Name: {e.Conveyer_name}, Numb: {e.Conveyer_numb}, Days: {e.Conveyer_day}, Resul: {e.Conveyer_result}, Failure: {e.Conveyer_failure}");
}

}








  }}


  