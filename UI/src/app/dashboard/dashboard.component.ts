import { Component, ChangeDetectionStrategy, Output, EventEmitter,  OnInit } from '@angular/core';
import {BehaviorSubject, EMPTY, Observable} from 'rxjs';
import { AuthService,  ICard} from './../services/auth.service';
import {DashboardService} from './../services/dashboard.service';
import {RegionService} from './../services/region.service';
import {Router} from '@angular/router';
import {MatTableDataSource} from '@angular/material/table';
import {AfterViewInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableModule} from '@angular/material/table';
import {CategoryService} from './../services/category.service';
import {MatPaginatorModule, PageEvent} from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';









@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

 

export class DashboardComponent implements  OnInit {
   cards$!: Observable<ICard[]>;
   
 
  

 
  constructor(
    private dashboardService: DashboardService,
    private router: Router,
    private route: ActivatedRoute,) {   
     
      
     
     }

  ngOnInit() {
    this.cards$ = this.dashboardService.getCardList({
       pageSize: 100,
       page: 0,
        });
  }

}


