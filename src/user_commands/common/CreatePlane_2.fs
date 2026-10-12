/**Custom Code*/
     double CaseHeight = Table("RackTable")[6][2];
     int LayerTier = CaseHeight*Table("RackTable")[14][2];

		Object plane1 = createinstance(node("MAIN:/project/exec/globals/visuallibrary/Plane"), model());
		double length1=23;
		double width1=55;
		setsize(plane1,length1,width1,0.5);
		setloc(plane1,-28,40,LayerTier);
