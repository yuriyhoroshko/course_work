# course_work
My course work, consists of api on .Net Core, frontend part on Angular, Windows worker service and installer on .Net Framework
Worker service collects Windows performance counters data, defined by installer (customizable) and sends to backend server. 
Backend server by request to api (JWT token for authorization) makes anomaly detection using ML.NET and returns time series data.
Frontend renders timeseries with anomalies using Angular, and ApexChart.JS (https://apexcharts.com/) library.
