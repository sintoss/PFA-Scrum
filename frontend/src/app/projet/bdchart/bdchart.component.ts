import {Component, OnInit, ViewChild} from '@angular/core';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexStroke,
} from 'ng-apexcharts';
import {SprintService} from '../../shared/services/sprint.service';
import {BacklogService} from '../../shared/services/backlog.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  stroke: ApexStroke;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
};

@Component({
  selector: 'app-bdchart',
  templateUrl: './bdchart.component.html',
  styleUrls: ['./bdchart.component.css'],
})
export class BdchartComponent implements OnInit {
  @ViewChild('chart')
  chart!: ChartComponent;
  public chartOptions!: Partial<ChartOptions>;
  daysRemaining: any;
  totalStories: any;
  actualStories!:any[];
  stories!: any[];
  sprintId!: number;

  idealChart()
  {
    let chartData=this.totalStories/(this.daysRemaining.length);
    let storyChart=[];
    storyChart.push(this.totalStories);
    for(let i =1;i<this.daysRemaining.length;i++)
    {
        storyChart.push(storyChart[i-1]-chartData);
    }
    console.log(storyChart);
    return storyChart;
  }


  constructor(private sprintService: SprintService, private backlogService: BacklogService) {

  }

  /*public generateData(baseval: any, count: any, yrange: any) {
    var i = 0;
    var series = [];
    while (i < count) {
      var x = Math.floor(Math.random() * (750 - 1 + 1)) + 1;
      var y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;
      const z = Math.floor(Math.random() * (75 - 15 + 1)) + 15;

      series.push([x, y, z]);
      baseval += 86400000;
      i++;
    }
    return series;
  }*/

  ngOnInit(): void {
    this.getSprintDays();
    // this.initChart();
  }

  getSprintDays() {
    this.backlogService.backId.subscribe((value: number) => {
      this.sprintService.getCurrentSprint(value).subscribe(response => {
        console.log(response);
        if((response as any).sprint != undefined){
          this.sprintId = (response as any).sprint.id;
          this.totalStories = (response as any).sprint.sprintStories.length;
          //this.actualStories.push(this.totalStories);
          this.stories=(response as  any).sprint.sprintStories;
          this.daysRemaining = (response as any).days;
          this.initChart();
        }
      });
    });
  }


  fillActual()
  {

      let duplicate = this.doneStories().reduce((accumulate, value) => ({
          ...accumulate, [value.dateFin]: (accumulate[value.dateFin] || 0) + 1
      }), {});

    Object.values(duplicate).reduce((accumulate:any, value:any) => {
          let res = accumulate -= value;
          this.actualStories.push(res);
          return res;
    }, this.actualStories);
    return this.actualStories;
  }

  doneStories()
  {
    return this.stories.filter(s=>s.isDone===true);
  }

  initChart() {
    this.chartOptions = {
      series: [
        {
          name: 'actual',
          data: [2,1.5, 1, 0]
        },
        {
          name: 'Ideal',
          data: this.idealChart()
        }
      ],
      chart: {
        height: 350,
        type: 'area'
      },
      dataLabels: {
        enabled: false
      },
      stroke: {
        curve: 'straight'
      },
      xaxis: {
        type: 'datetime',
        categories: this.daysRemaining
      },
      tooltip: {
        x: {
          format: 'dd/MM/yy'
        }
      }
    };
  }

}
