import {Component, Input} from '@angular/core';
import {IAdvertisement} from '../../models/advertisement/i-advertisement';
import {Router} from '@angular/router';
import { RouterService } from 'src/app/services/router.service';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-advertisement-card',
  templateUrl: './advertisement-card.component.html',
  styleUrls: ['./advertisement-card.component.scss']
})

export class AdvertisementCardComponent {
  @Input() advertisement: IAdvertisement;
  @Input() defaultImageUri: string;
  @Input() regionName: string;

  constructor(
    private readonly router: Router) {
  }
}