/**Custom Code*/
int numrow = Table("RackTable")[1][2];//排数
int number = Table("RackTable")[2][2] ;// 列数
int numlevels = Table("RackTable")[3][2];// 层数

//设置初始Source
Object originalSource1=Model.find("originalSource1");//找到对应输出端点实体
treenode sv=Model.find("originalSource1").find(">variables");
sv=sv.subnodes.assert("creationtrigger");
treenode node1=Model.find("Tools/UserCommands/SetOriginalSource/creationtrigger");
createcopy(node1,sv,1,0,0,1);
return sv;

//设置初始Combiner
//Object originalCombiner=Model.find("originalCombiner");//找到对应输出端点实体
//treenode usetransport=variables(originalCombiner).subnodes["sendtoport"];
//treenode node2=Model.find("Tools/UserCommands/SetOriginalSource/sendtoport");
//createcopy(node2,usetransport,1,0,0,1);
