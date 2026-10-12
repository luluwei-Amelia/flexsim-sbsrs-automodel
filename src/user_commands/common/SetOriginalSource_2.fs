/**Custom Code*/
int numrow = Table("RackTable")[1][2];//排数
int number = Table("RackTable")[2][2] ;// 列数
int numlevels = Table("RackTable")[3][2];// 层数

//设置初始Source
Object originalSource1=Model.find("originalSource1");//找到对应输出端点实体
treenode sv=Model.find("originalSource1").find(">variables");
sv=sv.subnodes.assert("creationtrigger");
treenode node1=Model.find("Tools/UserCommands/SetOriginalSource_2/creationtrigger");
createcopy(node1,sv,1,0,0,1);
return sv;
