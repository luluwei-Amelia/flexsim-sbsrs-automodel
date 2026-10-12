/**Custom Code*/
int UpConveyorNum = Table("UpTable")[1][2];//上箱线数量
int UpConveyorLength = Table("UpTable")[2][2] ;// 上箱线长度
int UpConveyorDistance = Table("UpTable")[3][2];//上箱线间距

double ConveyorHeight=Table("ConveyorTable")[3][2];


for(int i=1; i<=UpConveyorNum;i++)
{
  getvarnode(Model.find("UpCombiner"+numtostring(i)), "componentlist").as(Table)[1][1]=20;
  }
