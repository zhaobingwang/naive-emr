import service from '@/axios';

// export interface EmrDocument {
//   jsonContent: string;
// }

export function getDocument(id: string) {
  return service.get(`/EmrDocument/${id}`);
}

export function createDocument(data: any) {
  return service.post('/EmrDocument', data);
}
