/**Custom Code*/
Object ob=Model.find("mainDP");
treenode localType=getvarnode(ob,"localType");
treenode node1=Model.find("Tools/UserCommands/SetDP/onContinue");
treenode onContinue=localType.subnodes["onContinue"];
if(!objectexists(onContinue)){
	onContinue=localType.subnodes.assert("onContinue");
}
createcopy(node1,onContinue,1,0,0,1);
switch_flexscript(onContinue,1);
//reset();
