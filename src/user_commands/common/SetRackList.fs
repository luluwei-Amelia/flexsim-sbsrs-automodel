/**Custom Code*/
int numrow = Table("RackTable")[1][2];//排数
int number = Table("RackTable")[2][2] ;// 列数
int numlevels = Table("RackTable")[3][2];// 层数

for(int i=1;i<=numrow;i++){
	Object Rack=Model.find("Rack"+numtostring(i));//找到对应输出端点实体
	treenode usetransport=variables(Rack).subnodes["sendtoport"];
	treenode node1=Model.find("Tools/UserCommands/SetRackList/sendtoport");
	createcopy(node1,usetransport,1,0,0,1);
}
