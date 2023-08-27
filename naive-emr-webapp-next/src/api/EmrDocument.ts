import type { IEditorData } from '@zhao-internal/emr-editor'
import service from '@/axios'

export function createEmrDocument(data: IEditorData) {
  //   return service.post('/EmrDocument', { HeaderDto: data.header, MainDto: data.main, FooterDto: data.footer })
  return service.post('/EmrDocument', data)
}

export function getEmrDocument(guid: string) {
  return service.get('/EmrDocument/ED0A4605-6CC1-41FC-9372-FAB039829DAE')
}
