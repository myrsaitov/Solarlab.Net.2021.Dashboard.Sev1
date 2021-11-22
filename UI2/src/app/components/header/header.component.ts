import {AuthService} from '../../services/auth.service';
import {Component} from '@angular/core';
import {BaseService} from 'src/app/services/base.service';
import {Router} from '@angular/router';
import {ITag} from 'src/app/models/tag/tag-model';
import {TagService} from '../../services/tag.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Observable} from 'rxjs';

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
    private fb: FormBuilder,
    private authService: AuthService,
    private tagService: TagService,
    private readonly baseService: BaseService,
    private readonly router: Router) {
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

  getContent(){
    this.router.navigate(['/']);
  }
  getContentByTag(tag: string){
    this.router.navigate(['/'], { queryParams: { tag: tag } });
  }
  getAdvertisementCategoryId(categoryId: number){
    this.router.navigate(['/'], { queryParams: { categoryId: categoryId } });
  }
  getContentByUserName(){
    this.router.navigate(['/'], { queryParams: { userName: this.authService.getUserName() } });
  }

  get searchStr() {
    return this.form.get('searchStr');
}

  getContentBySearchStr(){
    this.router.navigate(['/'], { queryParams: { searchStr:  this.searchStr.value} });
  }

  userName(){
    return this.authService.getUserName();
  }

  logout() { //TODO зачем вызывать LogOut на бэке?
    /*this.baseService.post(ApiUrls.logout)
      .then(() => {
        this.router.navigate(['/', 'login']);
      })
      .finally(() => {
        this.authService.deleteSession();
      });*/
      this.router.navigate(['/', 'login']);
      this.authService.deleteSession();
  }
}