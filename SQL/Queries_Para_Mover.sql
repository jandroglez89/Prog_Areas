insert into [DB_BIM].[dbo].[Tipo_Edificio] (Tipo_Edificio) select distinct TipoEdificio from [ProgramaAreas].dbo.TipoEdificio

insert into [DB_BIM].[dbo].Subsistema_Tipo (Value) select distinct SubsistemaTipo from [ProgramaAreas].dbo.SubsistemaTipo

insert into [DB_BIM].[dbo].Subsistema_Area (Value) select distinct SubsistemaArea from [ProgramaAreas].dbo.SubsistemaArea

insert into [DB_BIM].[dbo].Grupo_Locales (Cod1, Value) select Cod1, GrupoLocales from ProgramaAreas.dbo.Cod1

insert into DB_BIM.dbo.Local ([Key_Name], Habitacion, SubsistemaTipo, SubsistemaArea, Grupo_Locales)
			select [Key Name], Habitacion, Subsistema_Tipo.Id, Subsistema_Area.Id, Grupo_Locales.Id from [ProgramaAreas].[dbo].[BaseDatos] 
			INNER JOIN DB_BIM.dbo.Subsistema_Tipo ON (BaseDatos.SubsistemaTipo = Subsistema_Tipo.Value)
			INNER JOIN DB_BIM.dbo.Subsistema_Area ON (BaseDatos.SubsistemaArea = Subsistema_Area.Value)
			INNER JOIN DB_BIM.dbo.Grupo_Locales ON (BaseDatos.Cod1 = Grupo_Locales.Cod1)