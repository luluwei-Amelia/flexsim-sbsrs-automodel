/**Custom Code*/
int numrow = Table("RackTable")[1][2];//排数
int numbay= Table("RackTable")[2][2] ;// 列数
int numlevels = Table("RackTable")[3][2];// 层数

int ShuttleNum = Table("ShuttleTable")[4][2];


//设置小车trigger
for(int i=1;i<=numrow/2;i++){
	for(int j=1;j<=ShuttleNum;j++){

Object TaskExecuter=Model.find("TaskExecuter"+numtostring(i)+numtostring(j));//找到对应输出端点实体
treenode sv=TaskExecuter.find(">variables");
sv=sv.subnodes.assert("resettrigger");
treenode node1=Model.find("Tools/UserCommands/SetShuttle/resettrigger");
createcopy(node1,sv,1,0,0,1);
//return sv;
	}
}
