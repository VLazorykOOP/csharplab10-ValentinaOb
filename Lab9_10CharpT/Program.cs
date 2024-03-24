﻿using System;
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
    //case 2: { task2();  break;}
    //case 3: { task3();  break;}
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


    if (a == k)
        {
            Console.Write("\nA & K Type Match");
        }
        else
        {
            throw new ArrayTypeMismatchException();
        }

    if(a[0]!=0){
        Console.Write("\nK[0]/A[0]:"+k[0]/a[0]);
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


public class Сonveyor{
  string name;
  int numb;
  int days;

  Worker work;

  public event WorkerEventHandler Work_fail;
  string[] result; 

  double failure;

  Worker workers;
  //Ambulance ambulanceman;
  //FireDetect fireman;


  //probability_of_worker_absence; //ймовірність відсутності робочих
  //probability_of_failure; //ймовірність несправності
  //probability_of_rejects; //ймовірність браку



  //public event FireEventHandler Fire;


  public void Conveyor(string name, int numb, int days){
    this.name = name;
    this.numb = numb;
    this.days = days;
    failure = 1e-3;

    workers = new Worker(this);
    //ambulanceman = new Ambulance(this);
    //fireman = new FireDetect(this);
    //policeman.On();
    //ambulanceman.On();
    //fireman.On();
  }


protected virtual void OnWork(WorkerEventArgs e)
 {
 const string MESSAGE_Work =
 $"On conveyer {sor} fail! Workers {5}. Day {13}";
 Console.WriteLine(string.Format(MESSAGE_Work, name,
 e.numb, e.day));
 if (Work_fail != null)
 {
 Delegate[] eventhandlers =
 Work_fail.GetInvocationList();
 result = new string[eventhandlers.Length];
 int k = 0;
 foreach (WorkerEventHandler evhandler in
 eventhandlers)
 {
 evhandler(this, e);
 result[k++] = e.Result;
 }
 }
 }


public void OurConv()
 {
 const string OK = $"On Conveyer {"k"} all is good!";
 bool wasfire = false;
 for (int day = 1; day <= days; day++)
 for (int numb = 1; building <= numb; numb++)
 {
 if (ran.NextDouble() < failure)
 {
 WorkerEventArgs e = new WorkerEventArgs(building, day);
 OnWork(e);
 wasfire = true;
 for (int i = 0; i < result.Length; i++)
 Console.WriteLine(result[i]);
 }
 }
 if (!wasfire)
 Console.WriteLine(string.Format(OK, name));
 }

public abstract class Receiver{
protected Worker work;
protected Random rnd = new Random();
public Receiver(Сonveyor conv)
 { this.work = work; }
 public void On()
 {
 work.wo += new WorkerEventHandler(It_is_Work);
 }
 public void Off()
 {
 work.wo -= new WorkerEventHandler(It_is_Work);
 }
 public abstract void It_is_Work(object sender, WorkerEventArgs e);
 }

public class Worker : Receiver
 {
 public Worker(Worker work) : base(work) { }
 public override void It_is_Work(object sender, WorkerEventArgs e)
 {
 const string OK =
 "Мiлiцiя знайшла винних!";
 const string NOK =
 "Мiлiцiя не знайшла винних! Наслiдок триває.";
 if (rnd.Next(0, 10) > 6)
 e.Result = OK;
 else e.Result = NOK;
 }
 }


public class WorkerEventArgs : EventArgs
 {
 int conv;
 int day;
 string result;
public int Conveyer_name
 { get { return conv; } }
 public int Conveyer_day
 { get { return day; } }
 public string Conveyer_result
 {
 get { return result; }
 set { result = value; }
 }

// Клас, задає вхiднi й вихiднi аргументи подiї
 public WorkerEventArgs(int conv, int day){
 this.conv = conv; this.day = day;
 }
 }

}
  }}


  