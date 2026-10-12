//int a=gettablenum("模式选择",1,2);//物流模式选择

int b=gettablenum("模式选择",2,2);//同端同层

int c=gettablenum("模式选择",3,2);//同端异层
int d=gettablenum("模式选择",6,2);//层数排布（同端异层）

int e=gettablenum("模式选择",4,2);//异端出入
int g=gettablenum("模式选择",7,2);//1-左入右出/2-右入左出（异端模式引用）

int f=gettablenum("模式选择",5,2);//视角

if(Table("模式选择")[1][2]=="A")//同端同层
{
  if(f==1) //1-正常视角
	{
	   if(b==1){main_A1();}
	   if(b==2){main_A2();}
	   if(b==3){main_A3();}
	}
  if(f==2) //2-180度视角
    {
	 if(b==4){main_A1();applicationcommand("changeperspview", "View 2");}
	 if(b==5){main_A2();applicationcommand("changeperspview", "View 2");}
	 if(b==6){main_A3();applicationcommand("changeperspview", "View 2");}
    }
}


if(Table("模式选择")[1][2]=="B")//同端异层
{
  if(f==1) //1-正常视角
  {
  	  if(d==1) //层数排布
  	   {
	    if(c==1){main_BT11();}
	    if(c==2){main_BT12();}
	    if(c==3){main_BT13();}
	    if(c==4){main_BT21();}
	    if(c==5){main_BT22();}
	    if(c==6){main_BT23();}
	    if(c==7){main_BT31();}
	    if(c==8){main_BT32();}
	    if(c==9){main_BT33();}
  	   }
  	  if(d==2) //层数排布
  	   {
	    if(c==1){main_BR11();}
	    if(c==2){main_BR12();}
	    if(c==3){main_BR13();}
	    if(c==4){main_BR21();}
	    if(c==5){main_BR22();}
	    if(c==6){main_BR23();}
	    if(c==7){main_BR31();}
	    if(c==8){main_BR32();}
	    if(c==9){main_BR33();}
  	   }
  }
  if(f==2) //2-180度视角
  {
  	  if(d==1) //层数排布
  	   {
	    if(c==1){main_BT11();applicationcommand("changeperspview", "View 2");}
	    if(c==2){main_BT12();applicationcommand("changeperspview", "View 2");}
	    if(c==3){main_BT13();applicationcommand("changeperspview", "View 2");}
	    if(c==4){main_BT21();applicationcommand("changeperspview", "View 2");}
	    if(c==5){main_BT22();applicationcommand("changeperspview", "View 2");}
	    if(c==6){main_BT23();applicationcommand("changeperspview", "View 2");}
	    if(c==7){main_BT31();applicationcommand("changeperspview", "View 2");}
	    if(c==8){main_BT32();applicationcommand("changeperspview", "View 2");}
	    if(c==9){main_BT33();applicationcommand("changeperspview", "View 2");}
  	   }
  	  if(d==2) //层数排布
  	   {
	    if(c==1){main_BR11();applicationcommand("changeperspview", "View 2");}
	    if(c==2){main_BR12();applicationcommand("changeperspview", "View 2");}
	    if(c==3){main_BR13();applicationcommand("changeperspview", "View 2");}
	    if(c==4){main_BR21();applicationcommand("changeperspview", "View 2");}
	    if(c==5){main_BR22();applicationcommand("changeperspview", "View 2");}
	    if(c==6){main_BR23();applicationcommand("changeperspview", "View 2");}
	    if(c==7){main_BR31();applicationcommand("changeperspview", "View 2");}
	    if(c==8){main_BR32();applicationcommand("changeperspview", "View 2");}
	    if(c==9){main_BR33();applicationcommand("changeperspview", "View 2");}
  	   }
  }
}

if(Table("模式选择")[1][2]=="C")//异端出入
{
  if(f==1) //1-正常视角
	{
	   if(e==1){main_CF11();}
	   if(e==2){main_CF12();}
	   if(e==3){main_CF13();}
	   if(e==4){main_CF21();}
	   if(e==5){main_CF22();}
	   if(e==6){main_CF23();}
	   if(e==7){main_CF31();}
	   if(e==8){main_CF32();}
	   if(e==9){main_CF33();}
	}
  if(f==2) //2-180度视角
	{
	   if(e==1){main_CF11();applicationcommand("changeperspview", "View 2");}
	   if(e==2){main_CF12();applicationcommand("changeperspview", "View 2");}
	   if(e==3){main_CF13();applicationcommand("changeperspview", "View 2");}
	   if(e==4){main_CF21();applicationcommand("changeperspview", "View 2");}
	   if(e==5){main_CF22();applicationcommand("changeperspview", "View 2");}
	   if(e==6){main_CF23();applicationcommand("changeperspview", "View 2");}
	   if(e==7){main_CF31();applicationcommand("changeperspview", "View 2");}
	   if(e==8){main_CF32();applicationcommand("changeperspview", "View 2");}
	   if(e==9){main_CF33();applicationcommand("changeperspview", "View 2");}
	}
}
