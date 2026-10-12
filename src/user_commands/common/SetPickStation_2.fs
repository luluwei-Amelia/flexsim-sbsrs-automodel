/**Custom Code*/
int AisleNum = Table("RackTable")[8][2];//排数
int PickNum = Table("ConveyorTable")[6][2];//排数

for(int j=1;j<=PickNum;j++){
		Object ob=Model.find("Station"+numtostring(j));
	treenode localType=getvarnode(ob,"localType");
	treenode node1=Model.find("Tools/UserCommands/SetPickStation_2/processTime");
	treenode node2=Model.find("Tools/UserCommands/SetPickStation_2/onProcessFinish");
	treenode onProcessFinish=localType.subnodes.assert("onProcessFinish");
	treenode processTime=localType.subnodes["processTime"];
	onProcessFinish=localType.subnodes["onProcessFinish"];
	createcopy(node1,processTime,1,0,0,1);
	switch_flexscript(processTime,1);
	createcopy(node2,onProcessFinish,1,0,0,1);
	switch_flexscript(onProcessFinish,1);
}



for(int i=1;i<=PickNum;i++){
Object oc=Model.find("PickMainDP"+numtostring(i));
treenode localType1=getvarnode(oc,"localType");
treenode node3=Model.find("Tools/UserCommands/SetPickStation_2/onContinue");
treenode onContinue=localType1.subnodes["onContinue"];
if(!objectexists(onContinue)){
	onContinue=localType1.subnodes.assert("onContinue");
 }
createcopy(node3,onContinue,1,0,0,1);
switch_flexscript(onContinue,1);
}

treenode ss=Model.find("pickSink").find(">variables");
ss=ss.subnodes["receivefromport"];
treenode node4=Model.find("Tools/UserCommands/SetPickStation_2/receivefromport");
createcopy(node4,ss,1,0,0,1);
return ss;
