/**Custom Code*/
int RowNum = Table("RackTable")[1][2];//排数
int BayNum = Table("RackTable")[2][2] ;// 列数
int TierNum = Table("RackTable")[3][2];// 层数
int AisleNum = Table("RackTable")[8][2];

for(int i=1;i<=AisleNum;i++){
	for(int j=1;j<=TierNum;j++){
		Object Queue=Model.find("Queue"+numtostring(2*i-1)+numtostring(j));//找到对应输出端点实体
		treenode usetransport=variables(Queue).subnodes["sendtoport"];
		treenode node1=Model.find("Tools/UserCommands/SetQueueIn/sendtoport");
		createcopy(node1,usetransport,1,0,0,1);
	}
}
