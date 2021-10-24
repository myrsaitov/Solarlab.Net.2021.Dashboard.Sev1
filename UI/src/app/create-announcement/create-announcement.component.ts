import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-announcement',
  templateUrl: './create-announcement.component.html',
  styleUrls: ['./create-announcement.component.scss']
})
export class CreateAnnouncementComponent implements OnInit {
  value = ''
  constructor() { }

  ngOnInit(): void {
  }

}
