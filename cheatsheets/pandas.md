SQLDF 

  from pandasql import sqldf 

 

 PANDAS 

  import pandas as pd 

 

 

 

· Información sobre objeto df 

  df.info() 

 

· Anular dinamización de series temporales (pasar de varias columnas a dos). 

 

  Por ejemplo, si tenemos las columnas: 
    'localización', 'indicador', '2015', '2016', '2017', '2018', '2019', '2020', '2021' 

 

  Podríamos pasar a : 

    'localización', 'indicador', 'año', 'valor' 

 

  df = pd.melt( 

    raw_df, 
    id_vars("localización", "indicador"), 
    var_name'año', 
    value_name'valor', 
  ) 

 

· Valores únicos sobre una columna. 

  df['column'].unique() 

 

· Mostrar información sobre el df 

  df.info() 

 

· Mostrar información sobre valores no numéricos de una columna del dataframe 

  null_vals = raw_df[pd.to_numeric(raw_df['DATA'], errors='coerce').isnull()]['DATA'].unique() 

 

· Mostrar filas con valores no numéricos 

  for v in null_vals: 
    v_rows= raw_df[raw_df['DATA'] == v] 
    print(str(len(v_rows)) + f" fila(s) con valor ['{v}']", end='\n\n') 
    print(v_rows.to_markdown(), end='\n\n') 

 

 

"CAPTURA DE DATOS" "TRANSFORMACIÓN" 

Lectura de datos de memoria a pandas: 

csv_data = response.content.decode("ISO-8859-2") 
raw_df = pd.read_csv(StringIO(csv_data)) 

 

 

 

 

 

