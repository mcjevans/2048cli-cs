using System;

public class Evans2048 {

       public bool gameover(int[,] arr) {
	 bool gameover = false;
//	       for (int i = 0; i < 3; i++){
//	       for (int j = 0; j < 3; j++){
	       if (gameover == true) {
	          printArr(arr);
	          Console.WriteLine("GAME OVER");
	          Environment.Exit(0);
	          }
//	       }}
	       return gameover;
	   }

	public void printArr(int[,] arr) {
       for (int i = 0; i < 4; i++) { 
       	   for (int j = 0; j < 4; j++) {
	       Console.Write(arr[i,j] + "\t");
	       }
	   Console.WriteLine();
	   }
	   }

	public void initRand(int[,] arr){
	int init = 0;
	while (init < 2) {
	      newRand(arr);
	      init++;
	      }
	}

	 public void newRand(int[,] arr){
	 bool b = false;
	 int rand1, rand2, rand3, x;
	 Random rand = new Random();
	 while (b == false) {
               rand1 = rand.Next(0, 4);
               rand2 = rand.Next(0, 4);
	       rand3 = rand.Next(0, 4);
	       if (arr[rand1, rand2] == 0) {
	       x = (rand3==0) ? 4 : 2; 
	       arr[rand1, rand2] = x;
	       b = true;
	       }
	 }
	 }
       
       static int Main()
       {
//	       a ^= b ^= a ^= b;


       int[,] arr = new int[4, 4]
       	       	   {
       	       	   {0,0,0,0},
		   {0,0,0,0},
       	       	   {0,0,0,0},
		   {0,0,0,0}
		   };


       Evans2048 o = new Evans2048();
       o.initRand(arr);
       Console.WriteLine();
       o.printArr(arr);

       o.readAndUpdate(arr);
       o.printArr(arr);	
	return 0;
       }

       public void readAndUpdate(int[,] arr){
	ConsoleKeyInfo ck = Console.ReadKey();
	Console.WriteLine();
	string str = ck.Key.ToString();
	Console.WriteLine(str);

	
	switch(str)
	{
	case "A":
		Console.WriteLine(str+"math()");
		Amath(arr);
		printArr(arr);
		readAndUpdate(arr);
		break;
	case "D":
		Console.WriteLine(str+"math()");
		Dmath(arr);
		printArr(arr);
		readAndUpdate(arr);
		break;
	case "S":
		Console.WriteLine(str+"math()");
		Smath(arr);
		printArr(arr);
		readAndUpdate(arr);
		break;
	case "W":
		Console.WriteLine(str+"math();");
		Wmath(arr);
		printArr(arr);
		readAndUpdate(arr);	
		break;
	default:
		Console.WriteLine(str + " read");
		break;
	  }
	}

	public void Amath(int[,] arr){
	   int n = 4;
	   for (int i = 0; i < n; i++) {
	       for (int j = 0; j < n; j++) {
	       	   if (j<n-1) {
		    	if (arr[i,j]==arr[i,j+1]) {
			   arr[i,j]*=2;
			   arr[i,j+1]=0;
			}
		   }
		}
	   }
//upmost should combine first
//directionmost, really
	   for (int h = 0; h < n; h++) {
		for (int i = 0; i < n; i++) {
	       	    for (int j = 0; j < n; j++) {
/*
			if (j<n-1) {
		    	if (arr[i,j]==arr[i,j+1]) {
			   arr[i,j]*=2;
			   arr[i,j+1]=0;}}
*/
			if ((j+1<n) && (arr[i,j]==0) && (arr[i,j] < arr[i,j+1])) {
		       	  swap(ref arr[i,j], ref arr[i,j+1]);
			}
		    }
		}
	   }
	   newRand(arr);
	}

	public void Dmath(int[,] arr){
	       int n = 4;
	       for (int i = 0; i < n; i++) {
		    for (int j = 0; j < n; j++) {
	    	    	if (j < n-1) {
		   	   if (arr[i,j]==arr[i,j+1]) {
			      arr[i,j+1]*=2;
			      arr[i,j]=0;
			   }
			}
		    }
	    	}

		for (int h = 0; h < n; h++) {
		    for (int i = 0; i < n; i++) {
		    	for (int j = 0; j < n-1; j++) {
			    if (arr[i,j+1]==0 && arr[i,j]>arr[i,j+1]) {
			       swap(ref arr[i,j], ref arr[i,j+1]);
			    }
			}
		    }
		}
		newRand(arr);
	}

	public void Smath(int[,] arr){
	       int n = 4;
	       for (int i = 0; i < n-1; i++) {
	       	   for (int j = 0; j < n; j++) {
		       if (arr[i,j]==arr[i+1,j]) {
		       	  arr[i,j] = 0;
			  arr[i+1,j] *= 2;
			  }
		    }
		}

		for (int h = 0; h < n; h++) {
		    for (int i = 1; i < n; i++) {
		    	for (int j = 0; j < n; j++) {
			    if (arr[i,j]==0 && arr[i-1,j]>arr[i,j])
			       swap(ref arr[i,j], ref arr[i-1,j]);
			}
		    }
		}
		newRand(arr);
	}

	public void Wmath(int[,] arr){
	       int n = 4;
	       for (int i = 0; i < n-1; i++) {
	       	   for (int j = 0; j < n; j++) {
		       if (arr[i,j]==arr[i+1,j]) {
		       	  arr[i+1,j]*=2;
			  arr[i,j]=0;
			}
		   }
		}

		for (int h = 0; h < n; h++) {
		    for (int i = 0; i < n-1; i++){
		    	for (int j = 0; j < n; j++) {
			    if(arr[i,j]==0 && arr[i+1,j]>arr[i,j]) swap(ref arr[i,j], ref arr[i+1,j]);
			}
		    }
		}
		newRand(arr);
	}     

	public void swap(ref int a, ref int b) {
	       int tmp = a;
	       a = b;
	       b = tmp;
	}
}
