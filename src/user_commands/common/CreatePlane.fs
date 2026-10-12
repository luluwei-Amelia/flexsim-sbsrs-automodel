/**Custom Code*/
     double CaseHeight = Table("RackTable")[6][2];
     int LayerTier = CaseHeight*Table("RackTable")[14][2];

		Object plane1 = createinstance(node("MAIN:/project/exec/globals/visuallibrary/Plane"), model());
		double length1=14;
		double width1=60;
		setsize(plane1,length1,width1,0.5);
		setloc(plane1,-20,50,LayerTier);

		Object plane2 = createinstance(node("MAIN:/project/exec/globals/visuallibrary/Plane"), model());
		double length2=60;
		double width2=20;
		setsize(plane2,length2,width2,0.5);
		setloc(plane2,-16,50,LayerTier);
