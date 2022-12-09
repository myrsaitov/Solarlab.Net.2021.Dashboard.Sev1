import { OwnerModel } from "../owner/owner-model";

export interface IComment {
  id: number;
  body: string;
  ownerId: string;
  owner: OwnerModel;
  createdAt: string;
  contentId: number;
  parentCommentId: number;
}
