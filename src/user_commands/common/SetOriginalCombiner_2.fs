/**Custom Code*/

//    getvarnode(Model.find("originalCombiner"), "componentlist").as(Table)[1][1]=20;

	Object originalCombiner=Model.find("originalCombiner");//找到对应输出端点实体
	treenode usetransport=variables(originalCombiner).subnodes["sendtoport"];
	treenode node1=Model.find("Tools/UserCommands/SetOriginalCombiner/sendtoport");
	createcopy(node1,usetransport,1,0,0,1);

	Object originalCombiner1=Model.find("originalCombiner");//找到对应输出端点实体
	treenode usetransport1=variables(originalCombiner1).subnodes["cycletime"];
	treenode node2=Model.find("Tools/UserCommands/SetOriginalCombiner/cycletime");
	createcopy(node2,usetransport1,1,0,0,1);

  //getvarnode(Model.find("originalCombiner"), "componentlist").as(Table)[1][1]=20;
