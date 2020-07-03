/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EscolaridadeService } from './escolaridade.service';

describe('Service: Escolaridade', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EscolaridadeService]
    });
  });

  it('should ...', inject([EscolaridadeService], (service: EscolaridadeService) => {
    expect(service).toBeTruthy();
  }));
});
