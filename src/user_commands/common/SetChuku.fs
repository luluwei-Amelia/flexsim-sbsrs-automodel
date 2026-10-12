/**Custom Code*/
//  Object chukuSource=Model.find("chukuSource");//找到对应输出端点实体
//  treenode usetransport1=variables(chukuSource).subnodes["interarrivaltime"];
//  treenode node2=Model.find("Tools/UserCommands/SetChuku/interarrivaltime");
//  createcopy(node2,usetransport1,1,0,0,1);



Object OutQueue=Model.find("OutQueue");//找到对应输出端点实体
treenode sv=Model.find("OutQueue").find(">variables");
sv=sv.subnodes.assert("entrytrigger");
treenode node1=Model.find("Tools/UserCommands/SetChuku/entrytrigger");
createcopy(node1,sv,1,0,0,1);
return sv;

  //Object chukuSource=Model.find("chukuSource");//找到对应输出端点实体
  //treenode usetransport1=variables(chukuSource).subnodes["interarrivaltime"];
  //treenode node2=Model.find("Tools/UserCommands/SetChuku/interarrivaltime");
  //createcopy(node2,usetransport1,1,0,0,1);
