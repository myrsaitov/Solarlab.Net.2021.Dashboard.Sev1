import {AuthService} from '../../services/auth.service';
import {Component} from '@angular/core';
import {ITag} from 'src/app/models/tag/tag-model';
import {TagService} from '../../services/tag.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Observable} from 'rxjs';
import { RouterService } from 'src/app/services/router.service';

// The @Component decorator identifies the class immediately below it as a component class, and specifies its metadata.
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
// ntcn
export class HeaderComponent {
  form: FormGroup;
  isAuth$ = this.authService.isAuth$;
  tags$: Observable<ITag[]>;

  constructor(
    private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private readonly tagService: TagService,
    private readonly router: RouterService) {
  }


  ngOnInit() {

    // Подписка на таги
    this.tags$ = this.tagService.getTagList({
      pageSize: 1000,
      page: 0,
    });

    // Валидаторы формы
    this.form = this.fb.group({
      searchStr: ['', Validators.required]
    });
  }

  userName(){
    return this.authService.getUserName();
  }

  logout() {
    this.router.goToLoginPage();
    this.authService.deleteSession();
  }

  // Обработка поиска по строке
  get searchStr() {
    return this.form.get('searchStr');
  }

  onKeyDownEnter(){
    this.router.getAdvertisementsBySearchStr(this.searchStr.value);
  }

}