/**Custom Code*/
//设置货物排列方式
int Row = Table("RackTable")[1][2];
int Tier = Table("RackTable")[3][2];
//int n = 1;
for(int i=1;i<=Row;i++){


	Object queue=Model.find("Rack"+numtostring(i));//找到对应输出端点实体
	treenode usetransport1=variables(queue).subnodes["placeinbay"];
	treenode node1=Model.find("Tools/UserCommands/SetRack/placeinbay");
	createcopy(node1,usetransport1,1,0,0,1);

	treenode usetransport2=variables(queue).subnodes["placeinlevel"];
	treenode node2=Model.find("Tools/UserCommands/SetRack/placeinlevel");//找到自编代码节点
	createcopy(node2,usetransport2,1,0,0,1);//


	treenode usetransport3=variables(queue).subnodes["minimumstaytime"];
	treenode node3=Model.find("Tools/UserCommands/SetRack/minimumstaytime");//找到自编代码节点
	createcopy(node3,usetransport3,1,0,0,1);//

//	n += 1;

}
