/**Custom Code*/
int UpConveyorNum = Table("UpTable")[1][2];//上箱线数量
int UpConveyorLength = Table("UpTable")[2][2] ;// 上箱线长度
int UpConveyorDistance = Table("UpTable")[3][2];//上箱线间距

//double ConveyorHeight=Table("ConveyorTable")[3][2];

//for(int i=1; i<=UpConveyorNum;i++){

//   Object source1=Model.find("source1"+numtostring(i));//找到对应输出端点实体
//   treenode sv=Model.find("source1"+numtostring(i)).find(">variables");
//   sv=sv.subnodes.assert("creationtrigger");
//   treenode node1=Model.find("Tools/UserCommands/SetSource/creationtrigger");
//   createcopy(node1,sv,1,0,0,1);

//}


//Object source1=Model.find("source1");//找到对应输出端点实体
//treenode sv=Model.find("source1").find(">variables");
//sv=sv.subnodes.assert("creationtrigger");
//treenode node1=Model.find("Tools/UserCommands/SetSource/creationtrigger");
//createcopy(node1,sv,1,0,0,1);
