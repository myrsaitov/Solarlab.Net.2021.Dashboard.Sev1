import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ICard } from 'src/app/services/auth.service';
import { DashboardService } from 'src/app/services/dashboard.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  card$!: Observable<ICard>;
  
  constructor(
    private dashboardService: DashboardService,
    private route:ActivatedRoute) { }

  ngOnInit(): void {
    
    this.route.params.subscribe( params =>{
      let id = params['id'];
      this.card$ = this.dashboardService.getCardById(id);
    }
  );
  }
  
 
}
