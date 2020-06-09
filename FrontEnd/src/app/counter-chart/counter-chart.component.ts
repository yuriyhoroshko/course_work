import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Options, PredictionOptions } from '../models/detection-options-model';
import ApiService from '../services/apiService';
import { ProcessedItem } from '../models/processed-counter-model';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTitleSubtitle,
  ApexStroke,
  ApexGrid,
  ApexAnnotations,
  PointAnnotations
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  annotations: ApexAnnotations;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  grid: ApexGrid;
  labels: string[];
  stroke: ApexStroke;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-counter-chart',
  templateUrl: './counter-chart.component.html',
  styleUrls: ['./counter-chart.component.less']
})
export class CounterChartComponent implements OnInit {
  private sub: any;

  public isLoading = false;
  public isLoaded = false;
  public options: PredictionOptions;
  public algorithmOptions: Options;
  public counterName: string;
  public serverId: number;
  public result: ProcessedItem[];
  public chartOptions: Partial<ChartOptions>;

  constructor(private route: ActivatedRoute, private apiService: ApiService) {
    this.algorithmOptions = {
      algorithm: 0,
      confidence: 0,
      judgementWindowSize: 0,
      pValueHistoryLength: 0,
      seasonalityWindowSize: 0,
      threshold: 0,
      trainingWindowSize: 0,
      windowSize: 0
    };
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
       console.log(params['counterName']);
       console.log(params['serverId']);

       this.options = {
        beginDate: null,
        endDate: null,
        counterName: params['counterName'],
        serverId: params['serverId'],
        options: this.algorithmOptions
       };
      });
  }

  public updateBeginDate = (date: Date) => {
    this.options.beginDate = date;
  }

  public updateEndDate = (date: Date) => {
    this.options.endDate = date;
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  public getData = async (isSsa: boolean) => {
    this.isLoading = true;
    this.algorithmOptions.algorithm = isSsa ? 0 : 1;
    this.options.options = this.algorithmOptions;

    await this.apiService.apiPost<ProcessedItem[]>(this.options, 'Counter/getPrediction').then(result => {
      if(result){
        console.log(result);
        this.result = result;
        this.chartOptions = {
          series:[{
            name: 'counter',
            data: this.result.map(val => val.value)
          }],
          chart: {
            type:'line',
            height: 700
          },
          annotations: {
            points:
            this.result.filter(el => el.isAnomaly).map(el => <PointAnnotations>{
              x: new Date(el.time).getTime(),
              y: el.value,
              marker:{
                size: 8,
                fillColor: "#fff",
                strokeColor: "red",
                radius: 2,
              },
              label: {
                borderColor: "#FF4560",
                  offsetY: 0,
                  style: {
                    color: "#fff",
                    background: "#FF4560"
                  },
                  text: 'Anomaly'
              }
            })
          },
          stroke: {
            curve: 'straight'
          },
          labels: this.result.map(el => el.time.toString()),
          xaxis: {
            type: 'datetime'
          }
        };
        this.isLoading = false;
        this.isLoaded = true;
    }});
  }
}
